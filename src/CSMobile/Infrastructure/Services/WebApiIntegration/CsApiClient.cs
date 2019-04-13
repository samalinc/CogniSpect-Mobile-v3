using System.Net.Http;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;
using CSMobile.Infrastructure.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Services.WebClient;

namespace CSMobile.Infrastructure.Services.WebApiIntegration
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