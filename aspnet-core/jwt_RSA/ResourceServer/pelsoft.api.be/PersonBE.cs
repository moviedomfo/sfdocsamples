using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celam.api.common.BE
{
    
    public partial class PersonList : Fwk.Bases.BaseEntities<PersonBE> { }

    
    public partial class PersonBE : Fwk.Bases.BaseEntity
    {
        
        

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public PersonBE() { }


        public Guid PersonId { get; set; }


        public Guid? UserId { get; set; }
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return LastName + ", " + Name; }
        }

        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public string IdentityCardNumber { get; set; }

        public int IdentityCardNumberType { get; set; }
        
        public string Email { get; set; }

        public int Sex { get; set; }

        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// F. alta
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Fecha de ultimo acceso
        /// </summary>
        public DateTime? UpdateDate { get; set; }




        public override string ToString()
        {
            return LastName + ", " + Name;
        }

        /// <summary>
        /// 
        /// </summary>
        ///public Byte[] Photo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String PhotoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public String PhotoB64 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String LastUserNameUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid LastAccessUserId { get; set; }

        /// <summary>
        /// algun estado parametrizadeo
        /// </summary>
        public int? Status { get; set; }


        public List<AddressBE> AddressBEList{ get; set; }
        public string Phone1_label { get;  set; }
        public string Phone2_label { get;  set; }
        public string Mail_label { get; set; }



        /// <summary>
        /// Overload equal operator
        /// Framework BE = Edm Entity Model 
        /// </summary>
        /// <param name="pPerson">Edm Model BE</param>
        //    public static explicit operator PersonBE(Person pPerson)
        //    {
        //        return new PersonBE(pPerson);
        //    }
    }
}
