using System;
using System.Collections.Generic;
using System.Text;

namespace pelsoft.api.common
{
    public class Requets
    {
        public Guid UserId { get; set; }
        public String ClientId { get; set; }

        public string SecurityProviderName { get; set; }
    }
}
