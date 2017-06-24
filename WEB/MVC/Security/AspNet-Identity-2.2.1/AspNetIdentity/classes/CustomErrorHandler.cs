using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace IdentitySample.Common
{
    /// <summary>
    /// Error HTTP 500 Internal server error (Error interno del servidor)
    /// El servidor web encontró una condición inesperada que le impidió completar la solicitud del cliente 
    /// para acceder a la URL requerida.
    /// http://www.dotnet-tricks.com/Tutorial/mvc/19D9140313-Exception-or-Error-Handling-and-Logging-in-MVC4.html
    /// </summary>
    public class PortalHandleErrorAttribute : HandleErrorAttribute
    {


        //private readonly ILog _logger;

        public PortalHandleErrorAttribute()
        {
            //_logger = LogManager.GetLogger("MyLogger");
        }
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        public override void OnException(ExceptionContext filterContext)
        {

            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else
            {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new PortalErrorInfo(filterContext.Exception, controllerName, actionName);
                model.ErrorId = String.Empty;

                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData

                };
            }

            // log the error using log4net.
            //_logger.Error(filterContext.Exception.Message, filterContext.Exception);

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }


      /// <summary>
    /// 
    /// </summary>
    public class PortalErrorInfo : HandleErrorInfo
    {
        public static PortalErrorInfo CreateNew(String message)
        {
            Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException(message);
           
            return new PortalErrorInfo(te, Helper.Controller(), Helper.Action());

        }
        public PortalErrorInfo(Exception exception, string controllerName, string actionName)
            : base(exception, controllerName, actionName)
        { }
      

        String _ErrorId;
        String ErrorTitle{get;set;}
        public String ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }
        String _Message = string.Empty;

        public String Message
        {
            get
            {

                if (this.Exception != null)
                    return Exception.Message;
                return _Message;
            }
            set { _Message = value; }
        }

        private String _StackTrace = string.Empty;

        public String StackTrace
        {
            get
            {
                if (this.Exception != null)
                    return Exception.StackTrace;
                return _StackTrace;
            }
            set { _StackTrace = value; }
        }

        public void Fill(string errorId, string message, string stackTrace)
        {
            _ErrorId = errorId;
            _Message = message;
            _StackTrace = stackTrace;
        }




       

        public string Redirect
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


    }

}