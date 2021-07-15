using Microsoft.IdentityModel.Tokens;
using pelsoft.auth.common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using fwkSec = fwk.security.identity.core;
using System.Linq;
namespace pelsoft.auth
{
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
            //var provider = fwkSec.SecurityManager.get_secConfig().GetByName(securityProvider.ToLowerInvariant());
            // var provider = Providers.Where(p => p.Name.ToLowerInvariant().Equals(securityProvider.ToLowerInvariant()));

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(provider.RsaPublicKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

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
