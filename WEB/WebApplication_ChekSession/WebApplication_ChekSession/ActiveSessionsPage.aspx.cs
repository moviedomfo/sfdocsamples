using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebApplication_ChekSession
{
    public partial class ActiveSessionsPage : System.Web.UI.Page
    {

        public string LIST;
        public string count;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

            StringBuilder str = new StringBuilder();

            //foreach (KeyValuePair<string, DateTime> u in activeUsers)
            //{
            //    str.AppendLine("<DIV>");
            //    str.AppendLine(string.Concat(u.Key, " inicio:  ", u.Value.ToString()));
            //    str.AppendLine("</DIV>");
            //}
            List<ActiveSession> wSessions = SessionMannager.Retrive_ActiveSessions();
            foreach (ActiveSession u in wSessions)
            {
                str.AppendLine("<DIV>");
                str.AppendLine(string.Concat("User ",u.UserName, " inicio:  ", u.LoggedInDate.ToString()));
                str.AppendLine("</DIV>");
            }
            LIST = str.ToString();

            count = wSessions.Count().ToString();
        }
    }
}
