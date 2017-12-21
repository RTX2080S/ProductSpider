using System.Threading.Tasks;
using ProductSpider.Clients.Interfaces;
using ProductSpider.Models;
using ProductSpider.Services.Interfaces;

namespace ProductSpider.Clients
{
    public class IMProductSpider : IIMProductSpider
    {
        protected readonly ISKUFormatter skuFormatter;
        protected readonly IHttpClientService httpClient;
        protected readonly IContentReader contentReader;

        public IMProductSpider(ISKUFormatter skuFormatter, IHttpClientService httpClient, IContentReader contentReader)
        {
            this.skuFormatter = skuFormatter;
            this.httpClient = httpClient;
            this.contentReader = contentReader;
        }

        public ProductDetails GetProductDetailsBySKU(string productDetailsUrl, string urlParams, int sku)
        {
            var fetchProductTask = this.GetProductDetailsBySKUAsync(productDetailsUrl, urlParams, sku);
            fetchProductTask.Wait();
            return fetchProductTask.Result;
        }

        public async Task<ProductDetails> GetProductDetailsBySKUAsync(string productDetailsUrl, string urlParams, int sku)
        {
            var formattedSKU = skuFormatter.GetFormattedSKUString(sku);
            var productUrl = $"{productDetailsUrl}{urlParams}{formattedSKU}";

            var downloadTask = await httpClient.DownloadDocumentAsyn(productUrl);

            var content = downloadTask;
            contentReader.SetContext(content);

            var productDetails = new ProductDetails();
            productDetails.SKU = sku;
            productDetails.Url = productUrl;
            productDetails.Title = contentReader.ReadContent("<title>", " - Product Details").Trim();
            productDetails.ImageUrl = contentReader.ReadContent("<a class=\"change-cursor\" href=\"", "\">").Trim();

            return productDetails;
        }
    }
}
