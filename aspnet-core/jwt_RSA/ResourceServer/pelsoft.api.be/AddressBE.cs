using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celam.api.common.BE
{
    public class AddressBE
    {

        public Guid PersonId { get; set; }

        public int AddressId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public global::System.String Street { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int16> StreetNumber { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public global::System.String Floor { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int32> CountryId { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int32> ProvinceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String CityId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public global::System.String Neighborhood { get; set; }
  
        /// <summary>
        /// 
        /// </summary>
        public global::System.String Province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public global::System.String City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public global::System.String ZipCode { get; set; }



    }
}
