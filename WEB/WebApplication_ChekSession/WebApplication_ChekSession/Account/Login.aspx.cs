using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_ChekSession.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
//            Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];


            e.Authenticated = Fwk.Security.FwkMembership.ValidateUser(LoginUser.UserName, LoginUser.Password, "AspNetSqlMembershipProvider");

        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {

            //Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];
            //if (!activeUsers.ContainsKey(LoginUser.UserName))
            //    activeUsers.Add(LoginUser.UserName, System.DateTime.Now);
            if (!SessionMannager.Any_ActiveSession(LoginUser.UserName))
                SessionMannager.Reg_ActiveSession(this.Session.SessionID, LoginUser.UserName);
            
        }

        protected void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            //Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

            //if (activeUsers.ContainsKey(LoginUser.UserName))
            //{
            //    e.Cancel = true;
            //    this.LoginUser.FailureText = "Ya ingresaste";
            //}
            if (SessionMannager.Any_ActiveSession(LoginUser.UserName))
            {
                e.Cancel = true;
                this.LoginUser.FailureText = "Ya ingresaste desde otra ubicacion";
            }
        }

        protected void LoginUser_LoginError(object sender, EventArgs e)
        {

        }

    }
}
