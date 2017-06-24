using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Principal;
using System.Web.Security;

namespace WebApplication_ChekSession
{
    public partial class _Default : System.Web.UI.Page
    {
        public string strUsers;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];
            if (activeUsers.ContainsKey(txtUserName.Text.Trim()))
            {
                Label1.Text = "Ya ingresaste";
                return;
            }
            Label1.Text = "";


            SetContact(Convert.ToInt32(txtUserName.Text.Trim()));

        }
        void SetContact(int contactId)
        {
            Session["Contact"] = null;
            using (AdventureWorksEntities dc = new AdventureWorksEntities())
            {

                Contact c = dc.Contact.Where(p => p.ContactID.Equals(contactId)).FirstOrDefault<Contact>();
                if (c == null)
                    Label1.Text = string.Format("Contact {0} mo existe", contactId);
                else
                    Session["Contact"] = c;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //GenericPrincipal genericPrincipal = GetGenericPrincipal();
            //GenericIdentity principalIdentity = (GenericIdentity)genericPrincipal.Identity;
            MembershipUser user = Membership.GetUser();
            if (user!=null)
                Label1.Text = string.Concat("El inicio de sesión pertenece a ", user.UserName);
            else
                Label1.Text = "No inicio sesión ninguin usuario";
        }

        private static GenericPrincipal GetGenericPrincipal()
        {
            // Use values from the current WindowsIdentity to construct
            // a set of GenericPrincipal roles.
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string[] roles = new string[10];
            if (windowsIdentity.IsAuthenticated)
            {
                // Add custom NetworkUser role.
                roles[0] = "NetworkUser";
            }

            if (windowsIdentity.IsGuest)
            {
                // Add custom GuestUser role.
                roles[1] = "GuestUser";
            }

            if (windowsIdentity.IsSystem)
            {
                // Add custom SystemUser role.
                roles[2] = "SystemUser";
            }

            // Construct a GenericIdentity object based on the current Windows
            // identity name and authentication type.
            string authenticationType = windowsIdentity.AuthenticationType;
            string userName = windowsIdentity.Name;
            GenericIdentity genericIdentity = new GenericIdentity(userName, authenticationType);

            // Construct a GenericPrincipal object based on the generic identity
            // and custom roles for the user.
            GenericPrincipal genericPrincipal = new GenericPrincipal(genericIdentity, roles);

            return genericPrincipal;
        }
    }
}
