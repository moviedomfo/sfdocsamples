using System.Security.Claims;

namespace pelsoft.auth.models
{
    public class UserClaims
    {
        public string UserId { get; set; }
        public ClaimsIdentity Claims { get; set; }
    }
}
