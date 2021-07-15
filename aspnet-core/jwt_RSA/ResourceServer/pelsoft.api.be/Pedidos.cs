using celam.api.common.BE;
using Fwk.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace celam.api.be
{
    public class PedidosBE 
    {
        public System.Int32? Id { get; set; }



        public System.Int32 ProviderId { get; set; }



        public System.Int32 QuotationRequestId { get; set; }



        public System.DateTime CreatedDate { get; set; }

        public int Status { get; set; }
        public string StatusName { get; set; }

        public List<PedidosDetailsBE>  Details { get; set; }

        public PedidosPersonData Person{ get; set; }


        public String ProviderName { get; set; }
        public string QuotationRequestObservations { get; set; }
    }

    public class PedidosDetailsBE 
    {
        public System.Int32 PedidoId { get; set; }
        public System.Int32 StockId { get; set; }
        public System.Decimal Count { get; set; }
        public System.String Description { get; set; }
        public System.Decimal OfferCost { get; set; }
        
        /// <summary>
        /// ESTO NO SE ALMACENA COMO TAL EN LA bd VIENE DEL FRONT
        /// </summary>



    }


    public class PedidosPersonData
    {
        public string ProviderName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string MailLabel { get; set; }
        public string Phone1label { get; set; }
        public string Phone2label { get; set; }


    }

}

