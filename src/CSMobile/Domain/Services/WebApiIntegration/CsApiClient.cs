using System.Net.Http;
using System.Threading.Tasks;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Interfaces.WebClient;

namespace CSMobile.Domain.Services.WebApiIntegration
{
    internal class CsApiClient : ICsApiClient
    {
        private readonly IWebApiClient _webApiClient;

        public CsApiClient(IWebApiClient webApiClient)
        {
            _webApiClient = webApiClient;
        }

        public async Task<WebApiResponse<AuthenticationResult>> Authenticate(UserAuthenticationData data)
        {
            return await _webApiClient.Request<AuthenticationResult>(new WebApiRequestOptions
            {
                Body = data,
                Method = HttpMethod.Post,
                Endpoint = ApiEndpoints.Authentication
            });
        }
    }
}