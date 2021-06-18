using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleGmailAPi
{
    public class socios_viewBEList : List<socios_viewBE>
    { }

    public class socios_viewBE 
    {
        public System.Int32 NroSocio { get; set; }



        public System.Int32 NroAbonado { get; set; }



        public System.String Nombre { get; set; }



        public System.String Apellido { get; set; }



        public Guid? UserId { get; set; }



        public System.Boolean Active { get; set; }



        public System.String UserName { get; set; }



        public System.String Email { get; set; }



        public System.String Direccion { get; set; }



        public System.Boolean? IsApproved { get; set; }



        public System.Boolean? IsLockedOut { get; set; }



        public System.String CUIT { get; set; }



        public System.String RUTA { get; set; }



        public System.String CODIGO_SUCURSAL { get; set; }



        public System.String CATEG { get; set; }



        public System.String RESPONSABILIDAD { get; set; }
        public string NOMBRES_ABONADOS { get; set; }
        public int IsImported { get; set; }
        public int IsRegistered { get; set; }
        public bool IsAuthorized { get; set; }
        public string AbonadoEmail { get; set; }
        public string AbonadoPhoneNumber { get; set; }

        public string Error { get; set; }
    }
}
