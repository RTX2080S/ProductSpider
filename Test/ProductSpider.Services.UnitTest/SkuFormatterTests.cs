using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSpider.Services;
using ProductSpider.Services.Interfaces;

namespace ProductSpider.Servicse.UnitTest
{
    [TestClass]
    public class SKUFormatterTests
    {
        private ISKUFormatter skuFormatter;

        [TestInitialize]
        public void Can_create_SKUFormatter()
        {
            skuFormatter = new SKUFormatter();
        }

        [TestMethod]
        public void SKUFormatter_get_correct_result_1()
        {
            int sku1 = 3392393;
            var expected = "000000000003392393";
            var actual = skuFormatter.GetFormattedSKUString(sku1);

            Assert.AreEqual(expected, actual);
        }

        [TestCleanup]
        public void Cleanup_SKUFormatter()
        {
            skuFormatter = null;
        }
    }
}
