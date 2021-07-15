using pelsoft.auth.Authenticators;
using pelsoft.auth.common;
using System.Collections.Generic;

namespace pelsoft.auth.Controllers
{
    public class PelsoftController : AuthenticationController
    {
        public PelsoftController(SecurityProviders providers,MockAuthenticator authenticator, IRefreshTokenProvider refreshTokenProvider) 
            : base(providers,authenticator, refreshTokenProvider, "pelsoft")
        {
        }
    }
}