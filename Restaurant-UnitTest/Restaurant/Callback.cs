using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IPersistence
    {
        Task StoreAsync(Product product, CancellationToken cancellationToken);
    }

    public class Callback
    {
        private readonly IPersistence _persistence;

        public Callback(IPersistence persistence)
        {
            _persistence = persistence;
        }

        public async Task StoreProduct(Product product)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                await _persistence.StoreAsync(product, cancellationTokenSource.Token);
            }
        }
    }
}
