using System;
using System.Configuration;
using ProductSpider.Clients;

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

            var productSpider = new IMProductSpider(ProductDetailsUrl, UrlParams);
            var productResult = productSpider.GetProductDetailsBySKU(dummySKU);
            
            Console.ReadLine();
        }
    }
}
