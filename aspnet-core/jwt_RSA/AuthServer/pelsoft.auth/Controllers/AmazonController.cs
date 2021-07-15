using pelsoft.auth.Authenticators;
using pelsoft.auth.common;
using System.Collections.Generic;

namespace pelsoft.auth.Controllers
{
    public class AmazonController : AuthenticationController
    {
        public AmazonController(SecurityProviders providers,MockAuthenticator authenticator, IRefreshTokenProvider refreshTokenProvider) 
            : base(providers,authenticator, refreshTokenProvider, "kcrm")
        {            
        }
    }
}