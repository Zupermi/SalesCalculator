using WebTest.Models;

namespace WebTest.Calculators
{
    public class SalesCalculator
    {
        public SalesStats CalculateSalesStats(List<Order> orders, List<Product> products, List<Discounts> discounts)
        {
            // Initialize variables for calculations
            decimal totalSalesBeforeDiscount = 0;
            decimal totalSalesAfterDiscount = 0;
            decimal totalDiscountAmount = 0;

            // Calculate metrics
            foreach (var order in orders)
            {
                decimal orderTotal = CalculateOrderTotal(order, products);

                totalSalesBeforeDiscount += orderTotal;

                decimal orderDiscount = CalculateOrderDiscount(order, discounts, orderTotal);

                totalDiscountAmount += orderDiscount;
                totalSalesAfterDiscount += orderTotal - orderDiscount;
            }

            decimal averageDiscountPercentage = totalSalesBeforeDiscount > 0 ? (totalDiscountAmount / totalSalesBeforeDiscount) * 100 : 0;

            return new SalesStats
            {
                TotalSalesBeforeDiscount = totalSalesBeforeDiscount,
                TotalSalesAfterDiscount = totalSalesAfterDiscount,
                TotalDiscountAmount = totalDiscountAmount,
                AverageDiscountPercentage = averageDiscountPercentage
            };
        }

        private decimal CalculateOrderTotal(Order order, List<Product> products)
        {
            return order.Items.Sum(item =>
            {
                var price = products.FirstOrDefault(p => p.Sku == item.Sku);
                if (price != default)
                    return price.Price * item.Quantity;
                return 0; // Handle case where product price is not found
            });
        }

        private decimal CalculateOrderDiscount(Order order, List<Discounts> discounts, decimal orderTotal) 
        {
            decimal calculatedDiscount = 0;

            if(order.Discounts == null) {
                return calculatedDiscount;
            }

            var orderDiscounts = order.Discounts.Split(',');

            foreach (var orderDiscount in orderDiscounts)
            {
                var discount = discounts.FirstOrDefault(d => d.Key == orderDiscount);
                if (discount != null)
                {
                    decimal discountAmount = discount.Value * orderTotal;
                    if (discount.Stacks.HasValue && discount.Stacks.Value)
                    {
                        calculatedDiscount += discountAmount;
                    }
                    else
                    {
                        calculatedDiscount = Math.Max(calculatedDiscount, discountAmount);
                    }
                }
            }
            return calculatedDiscount;
        }
    }
}