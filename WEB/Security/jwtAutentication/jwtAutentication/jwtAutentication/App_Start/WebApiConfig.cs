using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using jwtAuthentication.Controllers;

namespace jwtAuthentication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            //config.MessageHandlers.Add(new TokenValidationHandler());
            config.MessageHandlers.Add(new MessageHandler1());
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
