using System.Net;
using System.Threading.Tasks;

namespace EasyTravel.Contracts.Interfaces
{
    public interface IHttpService
    {
        Task<HttpWebResponse> MakeGetRequestAsync(string url, WebHeaderCollection headers,
            bool keepAlive = true);

        Task<HttpWebResponse> MakePostRequestAsync(string url, string data);
    }
}