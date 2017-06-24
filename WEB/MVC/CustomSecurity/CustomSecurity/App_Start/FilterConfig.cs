using System.Web;
using System.Web.Mvc;
using CustomSecurity.CustomAuthClass;

namespace CustomSecurity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomAuthenticationAttribute());
        }
    }
}