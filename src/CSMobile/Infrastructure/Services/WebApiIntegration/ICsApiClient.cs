using System.Threading.Tasks;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;
using CSMobile.Infrastructure.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Services.WebClient;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Services.WebApiIntegration
{
    public interface ICsApiClient
    {
        Task<WebApiResponse<AuthenticationResult>> Authenticate([NotNull] UserAuthenticationData data);
    }
}