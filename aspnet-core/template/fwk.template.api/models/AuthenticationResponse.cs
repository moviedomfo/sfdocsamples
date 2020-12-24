using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.template.models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }

        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }

        public AuthenticateResponse(string jwtToken, string refreshToken)
        {
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
