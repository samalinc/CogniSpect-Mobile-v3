using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Exceptions;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.WebClient
{
    public interface IWebApiClient
    {
        /// <summary>
        /// Makes request with specific options
        /// </summary>
        /// <param name="requestOptions"><see cref="WebApiRequestOptions"/></param>
        /// <exception cref="NotAuthorizedException"></exception>
        /// <exception cref="ForbiddenException"></exception>
        /// <exception cref="NotFoundException"></exception>
        /// <returns><see cref="WebApiResponse"/></returns>
        [ItemNotNull]
        Task<WebApiResponse> Request([NotNull] WebApiRequestOptions requestOptions);

        /// <summary>
        /// Makes request with specific options
        /// </summary>
        /// <param name="requestOptions"><see cref="WebApiRequestOptions"/></param>
        /// <typeparam name="TData">Type of requested object</typeparam>
        /// <exception cref="NotAuthorizedException"></exception>
        /// <exception cref="ForbiddenException"></exception>
        /// <exception cref="NotFoundException"></exception>
        /// <returns><see cref="WebApiResponse"/></returns>
        [ItemNotNull]
        Task<WebApiResponse<TData>> Request<TData>([NotNull] WebApiRequestOptions requestOptions) where TData : class;

        /// <summary>
        /// Makes GET request with specific options
        /// </summary>
        /// <param name="endPoint">Endpoint</param>
        /// <param name="securityOptions"><see cref="WebApiSecurityOptions"/></param>
        /// <typeparam name="TData">Type of requested object</typeparam>
        /// <exception cref="NotAuthorizedException"></exception>
        /// <exception cref="ForbiddenException"></exception>
        /// <exception cref="NotFoundException"></exception>
        /// <returns><see cref="WebApiResponse"/></returns>
        [ItemNotNull]
        Task<WebApiResponse<TData>> GetRequest<TData>([NotNull] string endPoint,
            WebApiSecurityOptions securityOptions = null) where TData : class;
    }
}