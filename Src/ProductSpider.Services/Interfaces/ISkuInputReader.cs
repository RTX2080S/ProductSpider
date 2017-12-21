using System.Collections.Generic;

namespace ProductSpider.Services.IO.Interfaces
{
    public interface ISkuInputReader
    {
        IList<int> Load(string inputFile);
    }
}