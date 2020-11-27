using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepcon.api.models
{
    public class ReciveActionReq
    {
        /// <summary>
        /// Identificador del usuario en la red social. 
        /// </summary>
        public string source_userid { get; set; }
        public string channel { get; set; }
        
        public string owner { get; set; }
        public string action { get; set; }


    }
}
