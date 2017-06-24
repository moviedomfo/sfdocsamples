using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebApplication_ChekSession
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// after the user clicks the logout link and the logout process is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                SessionMannager.Remove_ActiveSession(user.UserName);
                //Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

                //if (activeUsers.ContainsKey(user.UserName))
                //{
                //    activeUsers.Remove(user.UserName);
                //}
            }
        }
    }
}
