using System;
using System.Configuration;
using ProductSpider.Clients;
using System.Collections.Generic;
using ProductSpider.Models;

namespace ProductSpider.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ProductDetailsUrl = ConfigurationManager.AppSettings.Get(ConfigKeys.ProductDetailsUrl_Config_Key);
            string UrlParams = ConfigurationManager.AppSettings.Get(ConfigKeys.UrlParams_Config_Key);
            string inputFile = ConfigurationManager.AppSettings.Get(ConfigKeys.Input_File_Config_Key);
            string outputFile = ConfigurationManager.AppSettings.Get(ConfigKeys.Output_File_Config_Key);
            
            var skuReader = new SkuReader();
            var skuList = skuReader.Load(inputFile);
            
            var productDetails = new List<ProductDetails>();
            var productSpider = new IMProductSpider(ProductDetailsUrl, UrlParams);
            foreach (var sku in skuList)
            {
                var productResult = productSpider.GetProductDetailsBySKU(sku);
                productDetails.Add(productResult);
            }

            var csvWriter = new CsvWriter();
            csvWriter.Save(outputFile, productDetails);

            Console.WriteLine($"Done! CSV saved to {outputFile}.");
            Console.ReadLine();
        }
    }
}
