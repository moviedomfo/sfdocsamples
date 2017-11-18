using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// BE: BussinessEntity
/// </summary>
namespace Biblio.Common.BE
{
    public class LibroList : List<LibroBE>
    { }

    public class LibroBE
    {
        public System.Int32 IdLibro { get; set; }
        public System.String ISBN { get; set; }
        public System.String Titulo { get; set; }
        public System.String Autor { get; set; }
        public System.Int32? Stock { get; set; }
    }
}
