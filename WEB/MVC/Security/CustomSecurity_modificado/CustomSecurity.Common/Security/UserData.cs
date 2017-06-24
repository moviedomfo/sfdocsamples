using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace CustomSecurity.BE
{
    public class UserData  
    {

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Area { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }

        public UserData()
        {
            
        }



     
    }
}