﻿using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductSpider.Models;
using ProductSpider.Services.Helpers;
using Microsoft.Practices.Unity;
using ProductSpider.CLI.Helpers;
using ProductSpider.Services.IO.Interfaces;
using ProductSpider.Clients.Interfaces;

namespace ProductSpider.CLI
{
    class Program
    {
        static UnityContainer container;

        static void InitDependencies()
        {
            container = new UnityContainer();
            ContainerBootstrapper.RegisterTypes(container);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Application initializing...");
            InitDependencies();

            string ProductDetailsUrl = ConfigurationManager.AppSettings.Get(ConfigKeys.ProductDetailsUrl_Config_Key);
            string UrlParams = ConfigurationManager.AppSettings.Get(ConfigKeys.UrlParams_Config_Key);
            string inputFile = ConfigurationManager.AppSettings.Get(ConfigKeys.Input_File_Config_Key);
            string outputFile = ConfigurationManager.AppSettings.Get(ConfigKeys.Output_File_Config_Key);

            Console.WriteLine($"Loading input file {inputFile}...");
            var skuReader = container.Resolve<ISkuInputReader>();
            var skuList = skuReader.Load(inputFile);

            var productSpider = container.Resolve<IIMProductSpider>();
            var productDetails = new List<ProductDetails>();

            Console.WriteLine("Getting product details...");
            object lockResults = new object();
            Parallel.ForEach(skuList, sku =>
            {
                var productResult = productSpider.GetProductDetailsBySKU(ProductDetailsUrl, UrlParams, sku);
                lock (lockResults)
                {
                    productDetails.Add(productResult);
                    Console.WriteLine($"Get {sku} complete. ");
                }
            });

            Console.WriteLine($"Sorting product details...");
            var outputProducts = productDetails.ToInitialOrder(skuList);
            Console.WriteLine($"Saving CSV file {outputFile}...");
            var csvWriter = container.Resolve<IProductCsvWriter>();
            csvWriter.Save(outputFile, outputProducts);

            Console.WriteLine($"Done! CSV saved to {outputFile}.");
            Console.ReadLine();
        }
    }
}
