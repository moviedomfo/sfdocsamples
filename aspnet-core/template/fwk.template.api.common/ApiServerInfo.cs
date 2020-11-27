using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace keepcon.api.models
{
    public class ApiServerInfo
    {
        public string HostName { get; set; }
        public string SQLServerkeepcon { get; set; }
        public string SQLServerSeguridad { get; set; }
        public string Ip { get; set; }

        public string email { get; set; }
    }
}