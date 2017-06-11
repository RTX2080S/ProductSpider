using ProductSpider.Models;

namespace ProductSpider.Clients.Interfaces
{
    public interface IIMProductSpider
    {
        ProductDetails GetProductDetailsBySKU(int sku);
    }
}
