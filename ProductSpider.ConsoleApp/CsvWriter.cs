using System;
using System.Collections.Generic;
using System.IO;
using ProductSpider.Models;

namespace ProductSpider.ConsoleApp
{
    public class CsvWriter
    {        
        public void Save(string outputFile, IList<ProductDetails> productDetails)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(outputFile, false))
                {
                    foreach (var product in productDetails)
                    {
                        sw.WriteLine(string.Join(",", new string[] { product.Title, product.Url, product.ImageUrl }));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
