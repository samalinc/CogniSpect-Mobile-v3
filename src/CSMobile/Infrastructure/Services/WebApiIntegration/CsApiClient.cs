using System.Threading.Tasks;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;
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

        public Task<AuthenticationResponseData> Authenticate(UserAuthenticationData data)
        {
            // TODO: remove dummy data
            return Task.FromResult(new AuthenticationResponseData(true, "testtesttesttesttesttesttesttest"));
        }
    }
}