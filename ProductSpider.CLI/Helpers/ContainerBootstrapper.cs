using Microsoft.Practices.Unity;
using ProductSpider.Services.IO.Interfaces;
using ProductSpider.Services.IO;

namespace ProductSpider.CLI.Helpers
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<ISkuInputReader, SkuInputReader>();
            container.RegisterType<IProductCsvWriter, ProductCsvWriter>();
        }
    }
}
