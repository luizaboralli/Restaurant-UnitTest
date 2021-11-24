using System;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IDiscount
    {
        decimal CalculateTotalAfterDiscount(Product product);

        Task<decimal> CalculateTotalAfterDiscountAsync(Product product);
    }

    public class Discount: IDiscount
    {
        private const decimal DiscountSummer = 0.10m;
        private const decimal DiscountWinter = 0.15m;

        private readonly IClock _clock;

        public Discount(IClock clock)
        {
            _clock = clock;
        }

        public decimal CalculateTotalAfterDiscount(Product product) => CalculateTotalAfterDiscountInternal(product);

        public Task<decimal> CalculateTotalAfterDiscountAsync(Product product) => Task.Run(() => CalculateTotalAfterDiscountInternal(product));

        private decimal CalculateTotalAfterDiscountInternal(Product product)
        {
            if (product.Total == 0)
                throw new ArgumentException("Total should be bigger than zero.");

            if (_clock.GetDate(3).Month == 2 || _clock.Now.Month == 3)
            {
                return product.Total - (product.Total * DiscountSummer);
            }

            if (_clock.Now.Month == 9 || _clock.Now.Month == 10)
            {
                return product.Total - (product.Total * DiscountWinter);
            }

            return product.Total;
        }
    }
}
