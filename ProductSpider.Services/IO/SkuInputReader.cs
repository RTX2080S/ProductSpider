using System;
using System.Collections.Generic;
using System.IO;
using ProductSpider.Services.IO.Interfaces;

namespace ProductSpider.Services.IO
{
    public class SkuInputReader : ISkuInputReader
    {
        public IList<int> Load(string inputFile)
        {
            try
            {
                var result = new List<int>();
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    while (!sr.EndOfStream)
                    {
                        var skuStr = sr.ReadLine();
                        if (int.TryParse(skuStr, out int sku))
                        {
                            // Add only if the line is valid
                            result.Add(sku);
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
