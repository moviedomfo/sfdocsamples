using System;
using System.Collections.Generic;
using System.Net;
using pelsoft.api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pelsoft.api.service;
using Fwk.Exceptions;
using fwk.template.api.common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using pelsoft.template.models;
using Fwk.Security.Identity;
using pelsoft.auth.common;
using Microsoft.Extensions.Configuration;
using pelsoft.auth.helpers;

namespace pelsoft.api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private readonly IConfiguration Configuration;
        private readonly IRefreshTokenProvider _refreshTokenProvider;

        public SecurityController(IConfiguration _configuration, IRefreshTokenProvider refreshTokenProvider)
        {
            Configuration = _configuration;
            _refreshTokenProvider = refreshTokenProvider;

        }


        [HttpPost]
        [ProducesResponseType(typeof(loginResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult auth(loginRequest login)
        {
            if (string.IsNullOrEmpty(login.grant_type))
                login.grant_type = "password";
            try
            {
                if (login.grant_type == "refresh_token")
                {
                    var authenticateResponse = this.RefreshToken(login.refresh_token, IpAddress(), "kcrm");

                    loginResult res = new loginResult
                    {
                        token = authenticateResponse.JwtToken,
                        refresh_token = authenticateResponse.RefreshToken
                    };

                    return Ok(res);
                }
                else if (login.grant_type == "password")
                {
                    var authenticateResponse = this.Authenticate(login.username, login.password, "kcrm");

                    loginResult res = new loginResult
                    {
                        token = authenticateResponse.JwtToken,
                        refresh_token = authenticateResponse.RefreshToken
                    };

                    return Ok(res);
                }

                throw new InvalidOperationException("Esta situación es inalcanzable.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        /// <summary>
        /// Verifica un usuario (MOCK), y genera un access y refresh token correspondientes.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="securityProvider"></param>
        /// <returns></returns>
        private AuthenticateResponse Authenticate(string username, string password, string securityProvider)
        {
            var mokloging = new pelsoft.auth.models.mokloging();
            Configuration.Bind("mokloging", mokloging);

            if (password.Equals(mokloging.password) && username.Equals(mokloging.user))
            {
                SecurityUserBE user = new SecurityUserBE
                {
                    Email = "",
                    Id = Guid.NewGuid(),
                    UserName = username
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name.ToString(), user.UserName));

                var jwtTokenString = TokenGenerator.GenerateToken(claimsIdentity, securityProvider);
                var refreshTokenString = _refreshTokenProvider.GenerateRefreshToken(IpAddress(), user.Id.ToString()).Token;

                return new AuthenticateResponse(jwtTokenString, refreshTokenString);
            }
            else
            {
                throw new FunctionalException("Usuario o password incorrecto")
                {
                    ErrorId = HttpStatusCode.Unauthorized.ToString()
                };
            }
        }

        /// <summary>
        /// Obtiene los datos asociados al usuario identificado en el refresh_token, y genera un nuevo Access Token y Refresh Token
        /// </summary>
        /// <param name="refresh_token"></param>
        /// <param name="ipAddress"></param>
        /// <param name="securityProvider"></param>
        /// <returns></returns>
        private AuthenticateResponse RefreshToken(string refresh_token, string ipAddress, string securityProvider)
        {
            var tokenData = _refreshTokenProvider.FetchToken(refresh_token);

            var mokloging = new pelsoft.auth.models.mokloging();
            Configuration.Bind("mokloging", mokloging);

            SecurityUserBE user = new SecurityUserBE
            {
                Email = "",
                Id = Guid.NewGuid(),
                UserName = mokloging.user
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name.ToString(), user.UserName));

            var jwtTokenString = TokenGenerator.GenerateToken(claimsIdentity, securityProvider);
            var refreshTokenString = _refreshTokenProvider.RefreshToken(tokenData, ipAddress).Token;

            return new AuthenticateResponse(jwtTokenString, refreshTokenString);
        }
    }
}