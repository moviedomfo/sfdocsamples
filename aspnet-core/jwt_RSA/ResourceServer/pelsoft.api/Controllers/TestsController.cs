using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace pelsoft.api.Controllers
{
    public class validateDto
    {
        public string token { get; set; }
    }
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        public TestsController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        [Route("token")]
        [ProducesResponseType(typeof(string), Status200OK)]
        public IActionResult GenerateJwt()
        {

            var claims = new JwtCustomClaims
            {
                FirstName = "Vynn",
                LastName = "Durano",
                Email = "whatever@email.com"
            };

            var jwt = _jwtHandler.CreateToken(claims);

            //var link = _jwtHandler.GenerateLink(jwt.Token);

            return Ok(jwt);
        }

        [HttpPost]
        [Route("token/validate")]
        [ProducesResponseType(typeof(string), Status200OK)]
        public IActionResult ValidateJwt([FromBody] validateDto req)
        {

            if (_jwtHandler.ValidateToken(req.token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(req.token) as JwtSecurityToken;
                try
                {
                    var claims = new JwtCustomClaims
                    {
                        FirstName = jwtToken.Claims.First(claim => claim.Type == "Name").Value,
                        NameIdentifier = jwtToken.Claims.First(claim => claim.Type == "NameIdentifier").Value,
                        Email = jwtToken.Claims.First(claim => claim.Type == "Email").Value
                    };

                    return Ok(claims);
                }catch(Exception ex)
                {
                    BadRequest(ex.Message);
                }
                
            }

            return BadRequest("Token is invalid.");
        }
    }

}
