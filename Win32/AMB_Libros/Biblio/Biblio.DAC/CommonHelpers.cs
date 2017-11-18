using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Common
{
    public class CommonHelpers
    {
        public static string Cnnstring;
        static CommonHelpers()
        {
            Cnnstring  = ConfigurationManager.ConnectionStrings["biblioConnectionString"].ConnectionString;
        }
    }
}
