using System;
using System.Configuration;
using ProductSpider.Models;
using ProductSpider.Services;

namespace ProductSpider.ConsoleApp
{
    class Program
    {
        const string ProductDetailsUrl_Config_Key = "ProductDetailsUrl";
        const string UrlParams_Config_Key = "UrlParams";

        static void Main(string[] args)
        {
            string ProductDetailsUrl = ConfigurationManager.AppSettings.Get(ProductDetailsUrl_Config_Key);
            string UrlParams = ConfigurationManager.AppSettings.Get(UrlParams_Config_Key);
            int dummySKU = 3392393;

            var skuFormatter = new SKUFormatter();
            var formattedSKU = skuFormatter.GetFormattedSKUString(dummySKU);

            var productUrl = $"{ProductDetailsUrl}{UrlParams}{formattedSKU}";
            var httpClient = new HttpClientService();

            Console.WriteLine($"Downloading content -> {productUrl}...");

            var downloadTask = httpClient.DownloadDocumentAsyn(productUrl);
            downloadTask.Wait();

            var content = downloadTask.Result;

            var contentReader = new ContentReader();
            contentReader.SetContext(content);

            var productDetails = new ProductDetails();
            productDetails.Url = productUrl;
            productDetails.Title = contentReader.ReadContent("<title>", " - Product Details").Trim();
            productDetails.ImageUrl = contentReader.ReadContent("<a class=\"change-cursor\" href=\"", "\">").Trim();

            Console.WriteLine("Done! ");

            Console.ReadLine();
        }
    }
}
