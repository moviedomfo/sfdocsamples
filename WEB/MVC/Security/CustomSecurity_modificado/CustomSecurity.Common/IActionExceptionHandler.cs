using System.Web.Http.Filters;

namespace CustomSecurity.Common
{
    public interface IActionExceptionHandler
    {
        void HandleException(HttpActionExecutedContext filterContext);
    }
}