using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.api.models
{
    public class ReciveMessageReq 
    {
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
    }
}
