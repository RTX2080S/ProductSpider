using ProductSpider.Services.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace ProductSpider.Services
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient httpClient;

        public HttpClientService()
        {
            httpClient = new HttpClient();
        }
        
        public async Task<string> DownloadDocumentAsyn(string requestUri)
        {
            string doc = string.Empty;
            doc  = await httpClient.GetStringAsync(requestUri);
            return doc;
        }
    }
}
