using System.Web.Http;

namespace CustomSecurity.Common.Security
{
    public class AdministratorAuthorized : AuthorizeAttribute
    {
        public AdministratorAuthorized()
        {
            Roles = "Administrators";
        }
    }
}