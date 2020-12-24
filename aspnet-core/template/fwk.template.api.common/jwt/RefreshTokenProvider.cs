using Fwk.Exceptions;
using pelsoft.auth.common.storage;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace pelsoft.auth.common
{
    public interface IRefreshTokenProvider
    {
        RefreshToken FetchToken(string refreshToken);
        RefreshToken GenerateRefreshToken(string ipAddress, string userId);
        RefreshToken RefreshToken(RefreshToken refreshToken, string ipAddress);
        bool Revoke(string refreshToken, string ipAddress);
    }

    /// <summary>
    /// Clase para manejar tokens de refresco.
    /// Provee métodos para generar un token nuevo, renovar un token existente
    /// y revocar un token existente.
    /// Todos los métodos almacenan el resultado mediante ApiTokenStorage
    /// </summary>
    public class RefreshTokenProvider : IRefreshTokenProvider

    {
        IStore _store;
        public RefreshTokenProvider(IStore store)
        {
            _store = store;
        }

        /// <summary>
        /// Genera un nuevo refresh token
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public RefreshToken GenerateRefreshToken(string ipAddress, string userId)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddHours(12),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserID = userId
            };

            _store.Set(refreshToken.Token, refreshToken);
            return refreshToken;
        }
      
        /// <summary>
        /// Refresca el token, lo revoca, y almacena el nuevo.
        /// </summary>
        /// <param name="refreshToken">Token a refrescar</param>
        /// <param name="ipAddress">IP del generador</param>
        /// <returns>Nuevo token</returns>
        public RefreshToken RefreshToken(RefreshToken old_refresh_token, string ipAddress)
        {
            var refresh_token = GenerateRefreshToken(old_refresh_token.UserID, ipAddress);

            old_refresh_token.Revoked = DateTime.UtcNow;
            old_refresh_token.RevokedByIp = ipAddress;
            old_refresh_token.ReplacedByToken = refresh_token.Token;

            return refresh_token;
        }

        /// <summary>
        /// Obtener los datos del Token de almacenamiento.
        /// </summary>
        /// <param name="refresh_token">El código del Token</param>
        /// <returns><c>null</c> si el token está vencido o revocado; la información del token si es válido.</returns>
        public RefreshToken FetchToken(string refreshtoken)
        {
            var refresh_token = _store.Get(refreshtoken);

            if (refresh_token == null || !refresh_token.IsActive)
            {
                var fe = new FunctionalException("Token invalido o no existe");
                fe.ErrorId = "460";
                throw fe;
            }

            return refresh_token;
        }

        /// <summary>
        /// Revoca el token de refresco.
        /// </summary>
        /// <param name="refresh_token">Token a refrescar</param>
        /// <param name="ipAddress">IP del generador</param>
        /// <returns><c>true</c> si es revocado correctamente; <c>false</c> si estaba revocado o no existe</returns>
        public bool Revoke(string refreshToken, string ipAddress)
        {
            var refresh_token = FetchToken(refreshToken);

            refresh_token.Revoked = DateTime.UtcNow;
            refresh_token.RevokedByIp = ipAddress;
            _store.Remove(refresh_token.Token);
            _store.Set(refresh_token.Token, refresh_token);

            return true;
        }       
    }
}
