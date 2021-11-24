using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class OrderController : ControllerBase
    {
        private readonly IDiscount _discount;

        public OrderController(IDiscount discount)
        {
            _discount = discount;
        }

        /// <summary>
        /// Calculates the <see cref="Product"/> discount.
        /// </summary>
        /// <param name="product">Instance of <see cref="Product"/>.</param>
        /// <returns>The total with discount.</returns>
        [HttpPost]
        public decimal TotalWithDiscount(Product product)
        {
            return _discount.CalculateTotalAfterDiscount(product);
        }
    }
}
