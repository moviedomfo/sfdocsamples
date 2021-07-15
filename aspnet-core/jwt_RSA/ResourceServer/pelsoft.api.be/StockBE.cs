using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace celam.api.common.BE
{
    public class StockBE
    {
        public Int32 StockId { get; set; }
        public Decimal Cost { get; set; }
        public String Description { get; set; }
        public Int32 TypeId { get; set; }

        public string TypeName { get; set; }

        public DateTime LastAccessTime { get; set; }

        public Guid LastAccessUserId { get; set; }
        public decimal Stock { get; set; }

        public decimal StockMax { get; set; }
        public decimal StockAlertPersent { get; set; }

    }
}
