namespace TestP1
{
    public class SalesCalculator
    {
        public SalesStats CalculateSalesStats(List<Order> orders, Dictionary<int, decimal> products, Dictionary<string, decimal> discounts)
        {
            // Initialize variables for calculations
            decimal totalSalesBeforeDiscount = 0;
            decimal totalSalesAfterDiscount = 0;
            decimal totalDiscountAmount = 0;
            int discountCount = 0;

            // Calculate metrics
            foreach (var order in orders)
            {
                decimal orderTotal = order.Items.Sum(item =>
                {
                    if (products.TryGetValue(item.Sku, out decimal price))
                        return price * item.Quantity;
                    return 0; // Handle case where product price is not found
                });

                totalSalesBeforeDiscount += orderTotal;

                if (order.Discount != null && discounts.TryGetValue(order.Discount, out decimal discountPercentage))
                {
                    decimal discountAmount = discountPercentage * orderTotal;
                    totalDiscountAmount += discountAmount;
                    totalSalesAfterDiscount += orderTotal - discountAmount;
                    discountCount++;
                }
                else
                {
                    totalSalesAfterDiscount += orderTotal;
                }
            }

            // Calculate average discount per customer
            decimal averageDiscountPercentage = discountCount > 0 ? (totalDiscountAmount / totalSalesBeforeDiscount) * 100 : 0;



            return new SalesStats
            {
                TotalSalesBeforeDiscount = totalSalesBeforeDiscount,
                TotalSalesAfterDiscount = totalSalesAfterDiscount,
                TotalDiscountAmount = totalDiscountAmount,
                AverageDiscountPercentage = averageDiscountPercentage
            };
        }
    }
}