using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication_ChekSession
{
    public class Global : System.Web.HttpApplication
    {
        Dictionary<string,DateTime> activeUsers;
        void Application_Start(object sender, EventArgs e)
        {
            activeUsers = new Dictionary<string, DateTime>();
            Application["activeUsers"] = activeUsers;

        }

        void Application_End(object sender, EventArgs e)
        {
            

        }

        void Application_Error(object sender, EventArgs e)
        {
            

        }

        void Session_Start(object sender, EventArgs e)
        {
            //Si el usuario establecio recordar usuario y password en el browser.. se carga automaticamente el usuario
            MembershipUser user = Membership.GetUser();

            //if (user != null)
            //{
            //    Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

            //    if (!activeUsers.ContainsKey(user.UserName))
            //    {
            //        activeUsers.Add(user.UserName, System.DateTime.Now);
            //    }
            //}
            SessionMannager.Check_ActiveSession(user, this.Session.SessionID);
        }

        void Session_End(object sender, EventArgs e)
        {
            //Si la politica es quitar el usuario una vez finalizada su sesión realizamos lo siguiente
            //MembershipUser user = Membership.GetUser();
            //if (user != null)
            //{
            //    Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

            //    if (activeUsers.ContainsKey(user.UserName))
            //    {
            //        activeUsers.Remove(user.UserName);
            //    }
            //}
        }

    }
}
