using fwk.template.api.common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using pelsoft.api.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.api.middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiLogServices _logService;

        public ErrorHandlerMiddleware(RequestDelegate next, IApiLogServices logService)
        {
            _next = next;
            _logService = logService;
        }

        /// <summary>
        /// Este middleware atrapara todos los errores y los logueara
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(context, exception);
            }
        }

        /// <summary>
        /// Procesa el error (loguea y extrae otra info) al no hacer next produce un cortocircuito de la canalización
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private  Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            //var response = new { message = exception.Message };
            //var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400;
            var apiErrRes = new ApiErrorResponse(null, exception);
            var payload = JsonConvert.SerializeObject(apiErrRes);
            //return StatusCode(apiErrRes.StatusCode, apiErrRes);
            _logService.LogError_asynk(exception);
            return context.Response.WriteAsync(payload);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ErrorHandlerMiddlewareExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorHandlerMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
