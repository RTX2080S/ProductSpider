using System;
using System.Configuration;

namespace IMProductSpider
{
    class Program
    {
        const string ProductDetailsUrl_Config_Key = "ProductDetailsUrl";
        
        static void Main(string[] args)
        {
            string ProductDetailsUrl = ConfigurationManager.AppSettings.Get(ProductDetailsUrl_Config_Key);
            Console.WriteLine(ProductDetailsUrl);
            Console.ReadLine();
        }
    }
}
