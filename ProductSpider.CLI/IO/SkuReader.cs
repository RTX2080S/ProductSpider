using System;
using System.Collections.Generic;
using System.IO;

namespace ProductSpider.CLI.IO
{
    public class SkuReader
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
                        int sku;
                        var skuStr = sr.ReadLine();
                        if (int.TryParse(skuStr, out sku))
                            result.Add(sku);
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
