using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Services.WebClient
{
    public interface IWebApiClient
    {
        [ItemNotNull] Task<WebApiResponse> Request([NotNull] WebApiRequestOptions requestOptions);
        [ItemNotNull] Task<WebApiResponse<TData>> Request<TData>([NotNull] WebApiRequestOptions requestOptions);
    }
}