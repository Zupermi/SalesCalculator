using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestP1
{
    public class SalesStats
    {
        public decimal TotalSalesBeforeDiscount { get; set; }
        public decimal TotalSalesAfterDiscount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal AverageDiscountPercentage { get; set; }
    }
}
