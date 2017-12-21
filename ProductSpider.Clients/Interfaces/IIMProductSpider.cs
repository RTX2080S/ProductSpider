using ProductSpider.Models;
using System.Threading.Tasks;

namespace ProductSpider.Clients.Interfaces
{
    public interface IIMProductSpider
    {
        ProductDetails GetProductDetailsBySKU(string productDetailsUrl, string urlParams, int sku);
        Task<ProductDetails> GetProductDetailsBySKUAsync(string productDetailsUrl, string urlParams, int sku);
    }
}
