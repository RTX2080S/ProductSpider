﻿using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductSpider.Clients;
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

            Console.WriteLine("Application initializing...");

            Console.WriteLine($"Loading input file {inputFile}...");
            var skuReader = new SkuReader();
            var skuList = skuReader.Load(inputFile);

            var productDetails = new List<ProductDetails>();
            var productSpider = new IMProductSpider(ProductDetailsUrl, UrlParams);

            Console.WriteLine("Getting product details...");
            object lockResults = new object();
            Parallel.ForEach(skuList, sku =>
            {
                var productResult = productSpider.GetProductDetailsBySKU(sku);
                lock (lockResults)
                {
                    productDetails.Add(productResult);
                    Console.WriteLine($"Get {sku} complete. ");
                }
            });

            Console.WriteLine($"Saving CSV file {outputFile}...");
            var csvWriter = new CsvWriter();
            csvWriter.Save(outputFile, productDetails);

            Console.WriteLine($"Done! CSV saved to {outputFile}.");
            Console.ReadLine();
        }
    }
}
