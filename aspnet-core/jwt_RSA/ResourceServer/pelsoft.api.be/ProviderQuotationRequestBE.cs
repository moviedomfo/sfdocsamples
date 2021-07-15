using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celam.api.common.BE
{



    /// <summary>
    /// 
    /// </summary>
    public class ProviderStockOfferQuotationReqBE : IProviderStockOfferQuotationReqBE
    {

        public System.Int32 QuotationRequestId { get; set; }
        public System.Int32 ProviderId { get; set; }
        public System.Int32 StockId { get; set; }

        public System.Decimal Count { get; set; }

        public System.Decimal Cost { get; set; }

        /// <summary>
        /// Fecha de ultimo acceso
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        public Guid UserId { get; set; }
        public String UserName { get; set; }

        public bool BestOffer { get; set; }
        public String ProviderStockName { get; set; }
        
        public decimal Coef
        {
            get
            {
                {
                    if (Count != 0)
                        return Cost / Count;
                    else
                        return 0;

                }
            }
        }

        public decimal OrderedCount { get; set; }

        public int CompareTo( object obj)
        {
            ProviderStockOfferQuotationReqBE x = this;
            IProviderStockOfferQuotationReqBE y = (IProviderStockOfferQuotationReqBE)obj;
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're  equal. 
                    return 0;
                }
                else
                {
                    // X=null and Y is not null  (Y mayor) -1
                    return -1;
                }
            }
            else // If x is not null...
            {

                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    if (x.Coef > y.Coef)
                        return 1;

                    if (x.Coef < y.Coef)
                        return -1;

                    return 0;


                }
            }
        }

      
    }


    public class ProviderStockOfferQuotationReqFullInfoBE : ProviderStockOfferQuotationReqBE
    {
        public string ProviderName { get; set; }
        public string OrderDetailDescription { get; set; }
        public string ProviderDescription { get; set; }
    }
}
