using pelsoft.auth.Authenticators;
using pelsoft.auth.common;
using System.Collections.Generic;

namespace pelsoft.auth.Controllers
{
    public class PelsoftController : AuthenticationController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providers"></param>
        /// <param name="authenticator"></param>
        /// <param name="refreshTokenProvider"></param>
        public PelsoftController(SecurityProviders providers,MockAuthenticator authenticator, IRefreshTokenProvider refreshTokenProvider) 
            : base(providers,authenticator, refreshTokenProvider, "pelsoft")
        {
        }
    }
}