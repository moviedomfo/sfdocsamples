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
    public class SocioBEList : List<SocioBE>
    { }

    public class SocioBE
    {
        public int SocioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Estado { get; internal set; }

        public override string ToString()
        {
            return this.Apellido + ", " + this.Nombre;
        }
    }
}
