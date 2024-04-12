using Microsoft.AspNetCore.Mvc;
using WebTest.Models;
using WebTest.Calculators;

namespace WebTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;
        private readonly SalesCalculator _salesCalculator;

        public SalesController(ILogger<SalesController> logger, SalesCalculator salesCalculator)
        {
            _salesCalculator = salesCalculator;
            _logger = logger;
        }

        [HttpPost(Name = "SalesStatus")]
        public SalesStats SalesStatus([FromBody]SalesData sales)
        {
            return _salesCalculator.CalculateSalesStats(sales.Orders, sales.Products, sales.Discounts);
        }
    }
}
