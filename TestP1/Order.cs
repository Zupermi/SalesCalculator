using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestP1
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Discount { get; set; }
        public List<ProductOrder> Items { get; set; }
    }

    public class ProductOrder
    {
        public int Sku { get; set; }
        public int Quantity { get; set; }
    }
}
