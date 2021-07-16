using Microsoft.IdentityModel.Tokens;
using pelsoft.auth.common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using fwkSec = fwk.security.identity.core;
using System.Linq;
using System.Security.Cryptography;

namespace pelsoft.auth
{
    public static class TypeConverterExtension
    {
        /// <summary>
        /// Convierte base 64 text a byte[]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string value) => Convert.FromBase64String(value);

        /// <summary>
        /// Convierte byte cualquiera a Base64String
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string FromByteArray(this Byte[] buffer)
        {
            return Convert.ToBase64String(buffer);
        }
    }

    /// <summary>
    /// Clase para administrar tokens JWT
    /// </summary>
    public class TokenGenerator
    {
        //SecurityProviders Providers { get; }
        //public static  TokenGenerator(SecurityProviders providers)
        //{
        //    Providers = providers;

        //}
        /// <summary>
        /// Genera un token de acceso para el usuario <c>secUser</c>, seg�n
        /// la configuracin de <c>securityProvider</c>.
        /// 
        /// Provee el claim <c>Name</c>.
        /// </summary>
        /// <param name="claimsIdentity">Claims a almacenar en el token</param>B
        /// <param name="securityProvider">Nombre de la configuraci�n de seguridad a utilizar</param>
        /// <returns>Un JWT</returns>
        public static string GenerateToken(ClaimsIdentity claimsIdentity, SecurityProvider provider)
        {
            //https://vmsdurano.com/-net-core-3-1-signing-jwt-with-rsa/#google_vignette

            var privateKey = provider.RsaPrivateKey.ToByteArray();
            privateKey = Convert.FromBase64String(provider.RsaPrivateKey);
            using RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKey, out _);

            // var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(provider.RsaPrivateKey));
            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            // var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

            var jwtSecToken = new JwtSecurityToken(
                issuer: provider.Issuer,
                audience: provider.AudienceId,
                claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.AddSeconds(Convert.ToInt32(provider.TokenExpires)),
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenString = tokenHandler.WriteToken(jwtSecToken);

            return jwtTokenString;
        }


    }
}
