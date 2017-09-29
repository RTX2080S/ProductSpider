using ProductSpider.Models;

namespace ProductSpider.Clients.Interfaces
{
    public interface IIMProductSpider
    {
        ProductDetails GetProductDetailsBySKU(string productDetailsUrl, string urlParams, int sku);
    }
}
