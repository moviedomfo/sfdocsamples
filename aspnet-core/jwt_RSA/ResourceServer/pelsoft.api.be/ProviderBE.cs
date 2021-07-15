using Fwk.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// BE: BussinessEntity
/// </summary>
namespace celam.api.common.BE
{
  

    public class ProviderBEList : BaseEntities<ProviderBE>
    { }

    public class ProviderBE : BaseEntity
    {
        
        public ProviderBE()
        {

        }

        public Int32 ProviderId { get; set; }
        public Guid PersonId { get; set; }
        public string Name { get; set; }

        //public string IdentityCardNumber { get; set; }


        /// <summary>
        /// F. alta
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// algun estado parametrizadeo
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// Fecha de baja
        /// </summary>
        public DateTime? UpdateDate { get; set; }


        public Guid LastAccessUserId { get; set; }


        public PersonBE Person {get;set;}

        public string Description { get;  set; }
    }
}
