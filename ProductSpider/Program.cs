using ProductSpider.Services;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ProductSpider.Client
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

            Task<string> downloadTask = httpClient.DownloadDocumentAsyn(productUrl);
            downloadTask.Wait();

            var content = downloadTask.Result;

            using (StreamWriter sw = new StreamWriter("file.html"))
            {
                sw.Write(content);
            }

            Console.WriteLine("Done! ");

            Console.ReadLine();
        }
    }
}
