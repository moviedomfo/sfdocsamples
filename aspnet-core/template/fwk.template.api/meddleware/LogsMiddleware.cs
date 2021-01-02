using fwk.template.api.common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using pelsoft.api.common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.api.middleware
{
    /// <summary>
    /// Middlewre que perite loguear todas las entradas a las APIS: Se pueden agregar filtros tambien
    /// Aunque si filtracemos por URL convendria usar .Map --> Handler
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-5.0
    /// </summary>
    public class Logsmiddleware
    {
        public IConfiguration _configuration { get; }
        private readonly IApiLogServices _logService;

        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="configuration"></param>
        /// <param name="logService"></param>
        public Logsmiddleware(RequestDelegate next, IConfiguration configuration, IApiLogServices logService)

        {
            _configuration = configuration;
            _next = next;
            _logService = logService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //url de la peticion
            var url = UriHelper.GetDisplayUrl(context.Request);

            //Aqui leemos una variable de entorno directamente
            var k = _configuration.GetValue<string>("crypto:securityKey");
            //Aqui leeemos una seccion de Entorno
            var section = _configuration.GetSection("crypto:securityKey");
            
            

            //Aqui leemos un appSettings en json
            var cnn= _configuration.GetSection("ConnectionStrings");


            var api_enableLogRequets = _configuration.GetValue<bool>("apiConfig:api_enableLogRequets");

            if (api_enableLogRequets)
            {
                ApiEvent apiEvent = new ApiEvent();
                apiEvent.Type = EventType.Information;
                apiEvent.Source = url;

                //se envia el log en un segundo plano
                _logService.Log_asynk(apiEvent);
            }
            

            //pasamos la pelota inmediatamente al otro middleware (el que sigue)
            await _next(context);
     
            //no hacemos nada luego de la vuelta del middleware al que le pasamos la pelota


        }
    }


    public static class LogsMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogsMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Logsmiddleware>();
        }
    }
}
