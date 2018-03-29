using LocalAccountsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LocalAccountsApp.Controllers
{
    public class SecurityController : ApiController
    {
        // GET: api/Security
        public ManageInfoViewModel Get()
        {
            ManageInfoViewModel wManageInfoViewModel = new ManageInfoViewModel();
            wManageInfoViewModel.Email = "test@gmail.com";
            
            return wManageInfoViewModel;
        }

        // GET: api/Security/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Security
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Security/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Security/5
        public void Delete(int id)
        {
        }
    }

    
}

