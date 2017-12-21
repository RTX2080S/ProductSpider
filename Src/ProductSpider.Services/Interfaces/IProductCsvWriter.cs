using System.Collections.Generic;
using ProductSpider.Models;

namespace ProductSpider.Services.IO.Interfaces
{
    public interface IProductCsvWriter
    {
        void Save(string outputFile, IList<ProductDetails> productDetails);
    }
}