using System;
using System.Configuration;

namespace IMProductSpider
{
    class Program
    {
        const string ProductDetailsUrl_Config_Key = "ProductDetailsUrl";
        const string UrlParams_Config_Key = "UrlParams";

        static void Main(string[] args)
        {
            string ProductDetailsUrl = ConfigurationManager.AppSettings.Get(ProductDetailsUrl_Config_Key);
            string UrlParams = ConfigurationManager.AppSettings.Get(UrlParams_Config_Key);
            Console.WriteLine($"{ProductDetailsUrl}{UrlParams}");
            Console.ReadLine();
        }
    }
}
