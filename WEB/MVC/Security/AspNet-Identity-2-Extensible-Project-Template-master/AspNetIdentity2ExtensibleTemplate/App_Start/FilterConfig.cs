using Fwk.Exceptions;
using IdentitySample.Common;
using System.Web.Mvc;

namespace IdentitySample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new PortalHandleErrorAttribute
            {
                ExceptionType = typeof(System.Exception),
                View = "Error"
            });
            filters.Add(new PortalHandleErrorAttribute
            {
                ExceptionType = typeof(TechnicalException),
                View = "Error"
            });
        }
    }
}
