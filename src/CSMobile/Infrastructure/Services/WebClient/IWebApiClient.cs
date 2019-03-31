using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Services.WebClient
{
    public interface IWebApiClient
    {
        Task<WebApiResponse> Request(WebApiRequestOptions requestOptions);
        Task<WebApiResponse<TData>> Request<TData>(WebApiRequestOptions requestOptions);
    }
}