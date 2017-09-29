using Microsoft.Practices.Unity;
using ProductSpider.Services.IO.Interfaces;
using ProductSpider.Services.IO;
using ProductSpider.Services.Interfaces;
using ProductSpider.Services;
using ProductSpider.Clients.Interfaces;

namespace ProductSpider.CLI.Helpers
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<ISkuInputReader, SkuInputReader>();
            container.RegisterType<IProductCsvWriter, ProductCsvWriter>();
            container.RegisterType<ISKUFormatter, SKUFormatter>();
            container.RegisterType<IHttpClientService, HttpClientService>();
            container.RegisterType<IContentReader, ContentReader>();
            container.RegisterType<IIMProductSpider, IIMProductSpider>();
        }
    }
}
