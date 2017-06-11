using ProductSpider.Clients.Interfaces;
using ProductSpider.Models;
using ProductSpider.Services;
using ProductSpider.Services.Interfaces;

namespace ProductSpider.Clients
{
    public class IMProductSpider : IIMProductSpider
    {
        protected string ProductDetailsUrl;
        protected string UrlParams;

        protected ISKUFormatter skuFormatter;
        protected IHttpClientService httpClientService;
        protected IContentReader contentReader;

        public IMProductSpider(string productDetailsUrl, string urlParams)
        {
            ProductDetailsUrl = productDetailsUrl;
            UrlParams = urlParams;
            skuFormatter = new SKUFormatter();
            httpClientService = new HttpClientService();
            contentReader = new ContentReader();
        }

        public ProductDetails GetProductDetailsBySKU(int sku)
        {
            var formattedSKU = skuFormatter.GetFormattedSKUString(sku);

            var productUrl = $"{ProductDetailsUrl}{UrlParams}{formattedSKU}";

            var downloadTask = httpClientService.DownloadDocumentAsyn(productUrl);
            downloadTask.Wait();

            var content = downloadTask.Result;

            var contentReader = new ContentReader();
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
