using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using CustomSecurity.BE;
using CustomSecurity.DAC;
using Newtonsoft.Json;

namespace CustomSecurity.CustomAuthClass
{
    public class CustomAuthenticationAttribute : ActionFilterAttribute
    {
       public  String OuthRuleName  { get; set; }

        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Método ejecutado justo antes de la ejecución de la acción
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UserData wUserData = null;
            
            
            

            //[ModelBinder(typeof(UserDataModelBinder<UserData>))]
            if (filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                var cookie = filterContext
                    .RequestContext
                    .HttpContext
                    .Request
                    .Cookies[FormsAuthentication.FormsCookieName];

                if (null == cookie)
                {
                    //   throw new Exception("No inicio session correctemnete");
                    filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Home" }, { "action", "LogIn" } });
                }
               
                var decrypted = FormsAuthentication.Decrypt(cookie.Value);

                if (!string.IsNullOrEmpty(decrypted.UserData))
                    wUserData = JsonConvert.DeserializeObject<UserData>(decrypted.UserData);

                //TODO: Se podria armar un patron de nombre de recla con ControllerName+ActionNAme
//                String regla = filterContext.Controller.
                if (!String.IsNullOrEmpty(OuthRuleName))
                    UsersDAC.Authenticate(wUserData, OuthRuleName);

            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
             new RouteValueDictionary { { "controller", "Home" }, { "action", "LogIn" } });
            }
            base.OnActionExecuted(filterContext);

            // Almacenamos el nombre del método
            //log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ToString());

        }
    }
}