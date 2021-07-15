using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celam.api.common.BE
{
    
    

    /// <summary>
    /// Orden de cotizacion
    /// </summary>
    public  class QuotationRequestBE : Fwk.Bases.BaseEntity
    {



        public System.Int32 QuotationRequestId { get; set; }

        public System.String Observations { get; set; }

        public Guid UserId { get; set; }
        public String UserName { get; set; }

        

        public System.Int32 StatusId { get; set; }

        public System.String StatusText { get; set; }

        public System.String Conditions { get; set; }


        /// <summary>
        /// Fecha de ultimo acceso
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// lista de stoks
        /// </summary>
        public List<QuotationRequestDetailBE> QuotationRequestDetails { get; set; }


        /// <summary>
        /// lista de lso proveedores alos que se le solicita
        /// </summary>
        public List <OrderProviderAssignamentBE> OrderProviderAssignaments { get; set; }
}

    /// <summary>
    /// Detalle del pedido.. Articulo cantidad descripcion
    /// </summary>
    public  class QuotationRequestDetailBE : Fwk.Bases.BaseEntity
    {



        public System.Int32 QuotationRequestId { get; set; }

        public System.Int32 StockId { get; set; }

        public System.Decimal Count { get; set; }

        public System.String Description { get; set; }





    }
}
