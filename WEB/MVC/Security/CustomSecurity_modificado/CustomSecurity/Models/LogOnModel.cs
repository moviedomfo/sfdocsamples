using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomSecurity.BE;

namespace CustomSecurity.Models
{
    public class IndexModel 
    {
    }
    public class LogOnModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean RememberMe { get; set; }
    }
}