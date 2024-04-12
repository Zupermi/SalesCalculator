namespace WebTest.Models
{
    public class SalesData
    {
        public SalesData()
        {
            Orders = new List<Order>();
            Products = new List<Product>();
            Discounts = new List<Discounts>();
        }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<Discounts> Discounts { get; set; }
    }
}
