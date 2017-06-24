using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication_ChekSession
{
    public class SessionMannager
    {
        static string SessionsConnectionString;
        static SessionMannager()
        {
            SessionsConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SessionsConnectionString"].ConnectionString;
 
        }
        internal static void Check_ActiveSession(MembershipUser user, string sessionId)
        {
            

            if (user != null)
            {
//                Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

                //if (!activeUsers.ContainsKey(user.UserName))
                if (!Any_ActiveSession(user.UserName))
                {
                    //activeUsers.Add(user.UserName, System.DateTime.Now);
                    Reg_ActiveSession(sessionId,user.UserName);
                }
            }
        }


        internal static bool Any_ActiveSession(string userName)
        {
            using (SessionsDataDataContext dc = new SessionsDataDataContext(SessionMannager.SessionsConnectionString))
            {

                return dc.ActiveSessions.Any(s => s.UserName.Equals(userName));
            }
        }

       public  static void Reg_ActiveSession(string sessionId, string userName)
        {
            using (SessionsDataDataContext dc = new SessionsDataDataContext(SessionMannager.SessionsConnectionString))
            {
                ActiveSession a = new ActiveSession();
                a.UserName = userName;
                a.SessionID = sessionId;
                a.LoggedInDate = DateTime.Now;
                dc.ActiveSessions.InsertOnSubmit(a);
                dc.SubmitChanges();
            }
        }
       public static List<ActiveSession> Retrive_ActiveSessions()
       {
           using (SessionsDataDataContext dc = new SessionsDataDataContext(SessionMannager.SessionsConnectionString))
           {
               return dc.ActiveSessions.ToList < ActiveSession>();
               
               
           }
       }
       public static List<SessionHistory> Retrive_History()
       {
           using (SessionsDataDataContext dc = new SessionsDataDataContext(SessionMannager.SessionsConnectionString))
           {
               return dc.SessionHistories.ToList<SessionHistory>();


           }
       }
     public    static void Remove_ActiveSession(string userName)
        {
            using (SessionsDataDataContext dc = new SessionsDataDataContext(SessionMannager.SessionsConnectionString))
            {

                ActiveSession a = dc.ActiveSessions.Where(s=> s.UserName.Equals(userName)).FirstOrDefault<ActiveSession>();
                if (a != null)
                {
                    SessionHistory wSessionHistory = new SessionHistory();

                    wSessionHistory.UserName = a.UserName;
                    wSessionHistory.SessionID = a.SessionID;
                    wSessionHistory.StatusDate = a.LoggedInDate;
                    wSessionHistory.Status = "Log_In";

                    dc.SessionHistories.InsertOnSubmit(wSessionHistory);


                    wSessionHistory = new SessionHistory();

                    wSessionHistory.UserName = a.UserName;
                    wSessionHistory.SessionID = a.SessionID;
                    wSessionHistory.StatusDate = DateTime.Now;
                    wSessionHistory.Status = "Log_Out";

                    dc.SessionHistories.InsertOnSubmit(wSessionHistory);

                    dc.ActiveSessions.DeleteOnSubmit(a);

                    dc.SubmitChanges();
                }
            
            }
        }
    }
}