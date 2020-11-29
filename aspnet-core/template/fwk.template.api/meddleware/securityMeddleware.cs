using fwk.template.api.common.jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace pelsoft.api.meddleware
{
    /// <summary>
    /// Token Mannager Middleware
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-5.0
    /// </summary>
    public class TokenMannagerMiddleware :IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenManager _tokenManager;

        public TokenMannagerMiddleware(RequestDelegate next, ITokenManager tokenManager)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var url = UriHelper.GetDisplayUrl(context.Request);
            //var cultureQuery = context.Request.Query["culture"];

            //if (!string.IsNullOrWhiteSpace(cultureQuery))
            //{
            //    var culture = new CultureInfo(cultureQuery);

            //    CultureInfo.CurrentCulture = culture;
            //    CultureInfo.CurrentUICulture = culture;

            //}

            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                //The next parameter represents the next delegate in the pipeline. You can short-circuit the pipeline by not calling the next parameter
                //When a delegate doesn't pass a request to the next delegate, it's called short-circuiting the request pipeline.

               
                await context.Response.WriteAsync("No contiene , bearer header!");
            }

            if(await _tokenManager.IsCurrentActiveToken())
            {
                await _next(context);
                return;
            }

            //means the token is on the backlist and we shuldn´t allow the user to actually go futher refuse his requst--> because it was deactivated 
            //short-circuit
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            // Call the next delegate/middleware in the pipeline
            await _next(context);
            // Do logging or other work that doesn't write to the Response. 


        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }

        private string GetCurrentToken(HttpContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"];

            return authorizationHeader == StringValues.Empty ? string.Empty :
                        authorizationHeader.Single().Split(" ").Last(); //Bearer token
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public static class TokenMannagerMiddlewareExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseTokenMannagerMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenMannagerMiddleware>();
        }
    }
}
