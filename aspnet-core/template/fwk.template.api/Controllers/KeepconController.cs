
using pelsoft.api.Controllers;
using pelsoft.auth.Authenticators;
using pelsoft.auth.common;

namespace pelsoft.auth.Controllers
{
    public class KeepconController : AuthenticationController
    {
        public KeepconController(MockAuthenticator authenticator, IRefreshTokenProvider refreshTokenProvider) : base(authenticator, refreshTokenProvider, "kcrm")
        {
        }
    }
}