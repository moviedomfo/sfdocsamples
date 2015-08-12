using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PelsoftCOM
{
    public class Olecram
    {
        public string MethodA(string name)
        {
            return String.Concat("Hello, ", name);
        }
        public string MethodB(string name,int oldYears)
        {
            return String.Concat("Hello, ", name, " you`ve ", oldYears.ToString() );
        }
    }
}
