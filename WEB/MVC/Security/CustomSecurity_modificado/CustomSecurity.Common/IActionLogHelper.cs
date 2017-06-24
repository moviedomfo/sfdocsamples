using System.Web.Http.Controllers;

namespace CustomSecurity.Common
{
    public interface IActionLogHelper
    {
        void LogEntry(HttpActionDescriptor actionDescriptor);
        void LogExit(HttpActionDescriptor actionDescriptor);
        void LogAction(HttpActionDescriptor actionDescriptor, string prefix);
    }
}