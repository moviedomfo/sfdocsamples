using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Common.BE
{

    public class PrestamosViewList:List<PrestamosView>
       { }
    public class PrestamosView
    {

        public int IdPrestamo  {get;set;}
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaMovimiento { get; set; }

        public string Socio
        {
            get
            {
                return this.Apellido + ", " + this.Nombre;
            }
        }

        public string Estado { get; internal set; }
        //public int IdUsuario { get; internal set; }
    }
}
