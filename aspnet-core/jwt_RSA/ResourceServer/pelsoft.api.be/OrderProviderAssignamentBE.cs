using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celam.api.common.BE
{



    /// <summary>
    /// Asignaciones proveedores a los que se le solicita 
    /// </summary>
    public class OrderProviderAssignamentBE
    {

        public System.Int32 QuotationRequestId { get; set; }
        public System.Int32 ProviderId { get; set; }
        /// <summary>
        /// Fecha de ultimo acceso
        /// </summary>
        public DateTime UpdateDate { get; set; }
        public Guid UserId { get; set; }
        public string ProviderName { get; set; }
        public string Email { get; set; }


        public PersonBE Person { get; set; }
    }



}
