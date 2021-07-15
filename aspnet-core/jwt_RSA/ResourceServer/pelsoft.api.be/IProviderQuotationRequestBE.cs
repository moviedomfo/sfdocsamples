using System;

namespace celam.api.common.BE
{
    public interface IProviderStockOfferQuotationReqBE : IComparable
    {
        decimal Coef { get; }
        decimal Cost { get; set; }
        decimal Count { get; set; }
        int QuotationRequestId { get; set; }
        int ProviderId { get; set; }
        int StockId { get; set; }
        DateTime? UpdateDate { get; set; }
        Guid UserId { get; set; }
        string UserName { get; set; }
    }
}