using pelsoft.api.models;
using Fwk.Exceptions;
using Fwk.HelperFunctions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace pelsoft.api.service
{

    public interface IpelsoftService
    {
        void ReciveAction(ReciveActionReq req);

    }

    /// <summary>
    /// El nombre de esta clase podria ser generico si es que se utilizara la misma para todas las empresas 
    /// De momento se usa la implementcion epesifica de la interfaz para cada negocio
    /// </summary>
    public class pelsoftService : IpelsoftService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        public void ReciveAction(ReciveActionReq req)
        {
            try
            {
                var receivedUserId = pelsoftDAC.Insert(req);
                if (req.channel == "facebook")
                {
                    var accountDetailUnique = pelsoftDAC.Get_Facebook_Account(req.owner);
                    var detail = pelsoftDAC.Get_AccountDetail(accountDetailUnique);
                    
                    var settings = pelsoftDAC.Get_ApplicationSettings(188, detail.AccountId);

                    var log = pelsoftDAC.crear_caso(detail, settings, req.action, accountDetailUnique,req.source_userid, receivedUserId);

                }
            } 
            catch (Exception ex)
            {

                throw ex;
            }

        }

            
        

       
    }


}

