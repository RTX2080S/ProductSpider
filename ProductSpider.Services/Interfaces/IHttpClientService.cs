using System.Threading.Tasks;

namespace ProductSpider.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> DownloadDocumentAsyn(string requestUri);        
    }
}
