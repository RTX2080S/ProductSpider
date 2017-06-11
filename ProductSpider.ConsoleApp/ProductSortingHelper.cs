using System.Collections.Generic;
using ProductSpider.Models;
using System.Linq;

namespace ProductSpider.ConsoleApp
{
    public static class ProductSortingHelper
    {
        public static IList<ProductDetails> ToInitialOrder(this IList<ProductDetails> products, IList<int> initialOrder)
        {
            var result = new List<ProductDetails>();
            initialOrder.ToList().ForEach(x =>
            {
                var item = products.FirstOrDefault(p => p.SKU == x);
                result.Add(item);
            });
            return result;
        }
    }
}
