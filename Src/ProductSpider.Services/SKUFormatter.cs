using ProductSpider.Services.Interfaces;

namespace ProductSpider.Services
{
    public class SKUFormatter : ISKUFormatter
    {
        protected const int TOTAL_WIDTH = 18;

        public string GetFormattedSKUString(int SKU)
        {
            var skuStr = SKU.ToString();
            var result = skuStr.PadLeft(TOTAL_WIDTH, '0');
            return result;
        }
    }
}
