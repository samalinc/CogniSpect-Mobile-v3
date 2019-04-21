using System.Threading.Tasks;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Interfaces.WebClient;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.WebApiIntegration
{
    public interface ICsApiClient
    {
        Task<WebApiResponse<AuthenticationResult>> Authenticate([NotNull] UserAuthenticationData data);
    }
}