using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pelsoft.api.models
{
    public class ApiServerInfo
    {
        public string HostName { get; set; }
  
        public string Ip { get; set; }

        public string email { get; set; }

        public List<ConnectionStringInfo> cnnStrings{ get; set; }
}

    public class ConnectionStringInfo
    {
        public string name { get; set; }
        public string server { get; set; }
        public string database { get; set; }

    }
}