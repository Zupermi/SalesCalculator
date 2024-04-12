using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<ProductOrder>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        [JsonPropertyName("discount")]
        public string? Discounts { get; set; }
        public List<ProductOrder> Items { get; set; }
    }

    public class ProductOrder
    {
        public int Sku { get; set; }
        public int Quantity { get; set; }
    }
}
