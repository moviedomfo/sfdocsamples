using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fwk.Security.Identity;
using fwkSec = fwk.security.identity.core;


namespace pelsoft.auth.helpers
{
    /// <summary>
    /// Clase para administrar tokens JWT
    /// </summary>
    public class TokenGenerator
    {
        /// <summary>
        /// Genera un token de acceso para el usuario <c>secUser</c>, según
        /// la configuración de <c>securityProvider</c>.
        /// 
        /// Provee el claim <c>Name</c>.
        /// </summary>
        /// <param name="claimsIdentity">Claims a almacenar en el token</param>B
        /// <param name="securityProvider">Nombre de la configuración de seguridad a utilizar</param>
        /// <returns>Un JWT</returns>
        public static string GenerateToken(ClaimsIdentity claimsIdentity, string securityProvider)
        {
            var provider = fwkSec.SecurityManager.get_secConfig().GetByName(securityProvider);
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(provider.audienceSecret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecToken = new JwtSecurityToken(
                issuer: provider.issuer,
                audience: provider.audienceId,
                claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.AddSeconds(Convert.ToInt32(provider.expires)),
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenString = tokenHandler.WriteToken(jwtSecToken);

            return jwtTokenString;
        }
    }
}
