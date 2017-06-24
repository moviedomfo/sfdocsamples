using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureWcf
{

    public class WCFHelper
    {
      
            public const bool IncludeExceptionDetailInFaults =
            #if DEBUG
             true;
            #else
            false;
            #endif
        
    }
}