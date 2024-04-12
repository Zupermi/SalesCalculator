using Newtonsoft.Json;
using System.Collections.Generic;
using TestP1;

RunSalesCalculator();

static int RunSalesCalculator() {
    var discountJson = File.ReadAllText(@"C:\Proiecte\TestP1\TestP1\discounts.json");
    if (string.IsNullOrEmpty(discountJson))
        return 0;
    var discounts = JsonConvert.DeserializeObject<List<Discounts>>(discountJson);
    var discountsDictionary = new Dictionary<string, decimal>();
    discounts.ForEach(d => discountsDictionary.Add(d.Key, d.Value));

    var productsJson = File.ReadAllText(@"C:\Proiecte\TestP1\TestP1\products.json");
    if (string.IsNullOrEmpty(productsJson))
        return 0;
    var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
    var productsDictionary = new Dictionary<int, decimal>();
    products.ForEach(d => productsDictionary.Add(d.Sku, d.Price));

    var ordersJson = File.ReadAllText(@"C:\Proiecte\TestP1\TestP1\orders.json");
    if (string.IsNullOrEmpty(ordersJson))
        return 0;
    var orders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);

    var calculator = new SalesCalculator();

    var rez = calculator.CalculateSalesStats( orders, productsDictionary, discountsDictionary);

    Console.WriteLine($"Total sales before discount: {rez.TotalSalesBeforeDiscount}");
    Console.WriteLine($"Total sales after discount: {rez.TotalSalesAfterDiscount}");
    Console.WriteLine($"Total discount amount: {rez.TotalDiscountAmount}");
    Console.WriteLine($"Average discount percentage per customer: {rez.AverageDiscountPercentage}");

    return 0;
}

//SalesStats result = CalculateSalesStats(salesData, discountData);

//Console.WriteLine($"Total sales before discount: {result.TotalSalesBeforeDiscount}");
//Console.WriteLine($"Total sales after discount: {result.TotalSalesAfterDiscount}");
//Console.WriteLine($"Total discount amount: {result.TotalDiscountAmount}");
//Console.WriteLine($"Average discount percentage per customer: {result.AverageDiscountPercentage}");