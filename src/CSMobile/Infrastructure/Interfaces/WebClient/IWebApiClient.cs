using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.WebClient
{
    public interface IWebApiClient
    {
        [ItemNotNull]
        Task<WebApiResponse> Request([NotNull] WebApiRequestOptions requestOptions);

        [ItemNotNull]
        Task<WebApiResponse<TData>> Request<TData>([NotNull] WebApiRequestOptions requestOptions) where TData : class;

        [ItemNotNull]
        Task<WebApiResponse<TData>> GetRequest<TData>([NotNull] string endPoint,
            WebApiSecurityOptions securityOptions = null) where TData : class;
    }
}