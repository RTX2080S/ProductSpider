using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSpider.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> DownloadDocumentAsyn(string requestUri);        
    }
}
