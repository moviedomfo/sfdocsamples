
using Microsoft.IdentityModel.Tokens;
using pelsoft.api.common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace pelsoft.api
{
    public class JwtCustomClaims
    {
        public string FirstName { get; set; }
        public string NameIdentifier { get; set; }
        public string Email { get; set; }
    }

    public class JwtResponse
    {
        public string Token { get; set; }
        public long ExpiresAt { get; set; }
    }

    public interface IJwtHandler
    {
        JwtResponse CreateToken(JwtCustomClaims claims);
        bool ValidateToken(string token);
        // string GenerateLink(string token);
    }

    //public static class TypeConverterExtension
    //{
    //    public static byte[] ToByteArray(this string value) =>
    //     Convert.FromBase64String(value);
    //}

    public class JwtHandler: IJwtHandler
    {
        
        public JwtHandler()
        {
            
        }

        public JwtResponse CreateToken(JwtCustomClaims claims)
        {
            var privateKey = apiAppSettings.apiConfig.api_RsaPrivateKey.ToByteArray();

            using RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKey, out _);

            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            var now = DateTime.Now;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

            var jwt = new JwtSecurityToken(
                audience: apiAppSettings.apiConfig.api_audienceToken,
                issuer: apiAppSettings.apiConfig.api_issuerToken,
                claims: new Claim[] {
                    new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(nameof(claims.FirstName), claims.FirstName),
                    new Claim(nameof(claims.NameIdentifier), claims.NameIdentifier),
                    new Claim(nameof(claims.Email), claims.Email)
                },
                notBefore: now,
                expires: now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtResponse
            {
                Token = token,
                ExpiresAt = unixTimeSeconds,
            };
        }

        public bool ValidateToken(string token)
        {

           

            try
            {
                var publicKey = apiAppSettings.apiConfig.api_RsaPublicKey.ToByteArray();

                using RSA rsa = RSA.Create();
                rsa.ImportRSAPublicKey(publicKey, out _);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = apiAppSettings.apiConfig.api_issuerToken,
                    ValidAudience = apiAppSettings.apiConfig.api_audienceToken,
                    IssuerSigningKey = new RsaSecurityKey(rsa),

                    CryptoProviderFactory = new CryptoProviderFactory()
                    {
                        CacheSignatureProviders = false
                    }
                };
                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, validationParameters, out var validatedSecurityToken);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        //public string GenerateLink(string token) =>
        //     $"{_settings.ReferralUrl}/{_settings.ReferralId}/foo?token={token}";

    }
}


