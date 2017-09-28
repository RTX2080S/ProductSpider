using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProductSpider.Models;

namespace ProductSpider.Services.IO
{
    public class ProductCsvWriter
    {
        public void Save(string outputFile, IList<ProductDetails> productDetails)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(outputFile, false))
                {
                    productDetails.ToList().ForEach((product) =>
                    {
                        sw.WriteLine(string.Join(",", new string[] { product.Title, product.Url, product.ImageUrl }));
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
