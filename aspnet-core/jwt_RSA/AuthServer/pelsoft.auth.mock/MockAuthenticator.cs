using pelsoft.auth.helpers;
using pelsoft.auth.models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using pelsoft.auth.common;

namespace pelsoft.auth.Authenticators
{
    public class MockAuthenticator : IAuthenticator
    {
        private readonly IConfiguration Configuration;
        private readonly MockLogins moklogings;
        public MockAuthenticator(IConfiguration _configuration)
        {
            Configuration = _configuration;

            moklogings = new MockLogins();
            Configuration.Bind("moklogings", moklogings);
        }


        public UserClaims Authenticate(AuthenticationRequest req)
        {
            var caseInsensitiveParameters = new Dictionary<string, JsonElement>(req.AdditionalData, StringComparer.OrdinalIgnoreCase);
            var username = caseInsensitiveParameters["username"].GetString();
            var password = caseInsensitiveParameters["password"].GetString();

            

            var moklogingProviders = moklogings.Where(p => p.provider.Equals(req.security_provider, StringComparison.InvariantCultureIgnoreCase));

            if (moklogingProviders == null)
            {
                throw new AuthorizationException("No existe el provedor de seguridad " + req.security_provider);
            }
            var  mokloging = moklogingProviders.Where(p => p.user.Equals(username.ToLower(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (mokloging == null)
            {
                throw new AuthorizationException("Usuario o password incorrecto");
            }

            if (password.Equals(mokloging.password) && username.Equals(mokloging.user))
            {
                var user = new
                {
                    Email = "mockuser@pelsoft.com",
                    Id = Guid.NewGuid(),
                    UserName = username
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name.ToString(), user.UserName));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email.ToString(), user.Email));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier.ToString(), user.UserName));
                return new UserClaims
                {
                    UserId = user.Id.ToString(),
                    Claims = claimsIdentity
                };
            }
            else
            {
                throw new AuthorizationException("Usuario o password incorrecto");
            }
        }

        public UserClaims FetchUser(AuthenticationRequest req, string userId)
        {
            var mokloging = new MockLogin();
            Configuration.Bind("mokloging", mokloging);

            var user = new
            {
                Email = "",
                Id = new Guid(userId),
                UserName = mokloging.user
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name.ToString(), user.UserName));

            return new UserClaims
            {
                UserId = user.Id.ToString(),
                Claims = claimsIdentity
            };
        }
    }
}
