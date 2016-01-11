using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Security.ActiveDirectory;
using Fwk.Exceptions;
//using Fwk.CentralizedSecurity.Contracts;

namespace Fwk.CentralizedSecurity.Service
{
    public class ActiveDirectoryService
    {
       public static string CnnStringName =  "AD";
       static bool  performCustomWindowsContextImpersonalization= false;
       static List<DomainUrlInfo> DomainUrlInfoList = null;
       static ActiveDirectoryService()
       {
           DomainUrlInfoList = new List<DomainUrlInfo>();
           DomainUrlInfo wDomainUrlInfo = new DomainUrlInfo();
           wDomainUrlInfo.DomainName = "ALLUS-AR";
           wDomainUrlInfo.DomainDN = "DC=allus,DC=ar";
           wDomainUrlInfo.LDAPPath = "LDAP://allus.ar/DC=allus,DC=ar";
           //reseteos
           wDomainUrlInfo.Usr = "LDAP_Reseteo_WSReset";
           //reseteos
           wDomainUrlInfo.Pwd = "*R3s3t30s+";
           wDomainUrlInfo.Id = 0;

           DomainUrlInfoList.Add(wDomainUrlInfo);
       }

       internal static LoogonUserResult User_Logon(string userName, string password, string domain)
       {
           LoogonUserResult loogonUserResult = new LoogonUserResult();
           loogonUserResult.Autenticated = false;
           try
           {
               ImpersonateLogin wImpersonateLogin = GetImpersonate(domain);
               ADWrapper ad = new ADWrapper(wImpersonateLogin);
               TechnicalException logError = null;

               loogonUserResult.LogResult = ad.User_Logon32(userName, password, out logError).ToString();

               if (logError != null)
                   loogonUserResult.ErrorMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(logError);
               else
               {
                   loogonUserResult.ErrorMessage = string.Empty;
                   loogonUserResult.Autenticated = true;
               }


           }
           catch (Exception ex)
           {
               loogonUserResult.ErrorMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
           }
           return loogonUserResult;
       }
       
     


        //internal static ActiveDirectoryUser[] GetUsersFromGroup(string groupName, string domain)
        //{
        //    ADWrapper ad = new ADWrapper(domain, ActiveDirectoryService.CnnStringName);

        //    List<ADUser> list = ad.Users_SearchByGroupName(groupName);

        //    ad.Dispose();
        //    if (list.Count != 0)
        //    {
        //        var userList = from u in list select new ActiveDirectoryUser(u);

        //        return userList.ToArray<ActiveDirectoryUser>();
        //    }
        //    else
        //        return null;
        //}


        internal static bool UserExist(string userName, string domain )
        {

            ImpersonateLogin wImpersonateLogin = GetImpersonate(domain);
            ADWrapper ad = new ADWrapper(wImpersonateLogin);

            bool exist= ad.User_Exists(userName);

            ad.Dispose();

            return exist;
        }

      
       

        internal static void User_Unlock(string userName, string domain)
        {
            ImpersonateLogin wImpersonateLogin = GetImpersonate(domain);
            ADWrapper ad = new ADWrapper(wImpersonateLogin);
            
            //ad.User_SetLockedStatus(userName, false);
            ad.User_Unlock(userName);

            ad.Dispose();
        }

  


     

       

        internal static void User_Reset_Password(string userName, string newPassword, string domain)
        {
            ImpersonateLogin wImpersonateLogin = GetImpersonate(domain);
            
            ADWrapper ad = new ADWrapper(wImpersonateLogin);

            //ADWrapper ad3 = new ADWrapper(domain,"reseteos","*R3s3t30s+");
            ad.User_ResetPwd(userName, newPassword ,true);

            ad.Dispose();
        }

        static ImpersonateLogin GetImpersonate(string domain)
        {
              
            DomainUrlInfo wDomainUrlInfo = DomainUrlInfoList.Where(p => p.DomainName == domain).FirstOrDefault();
            ImpersonateLogin wImpersonateLogin = new ImpersonateLogin();
            wImpersonateLogin.domain = wDomainUrlInfo.DomainName;
            wImpersonateLogin.user = wDomainUrlInfo.Usr;
            wImpersonateLogin.password = wDomainUrlInfo.Pwd;
            wImpersonateLogin.PerformWindowsContextImpersonalization = true;
            return wImpersonateLogin;
        }


       
        internal static List<DomainUrlInfo> GetAllDomainsUrl()
        {


            return DomainUrlInfoList;
        }



    }

    
}
