using System.Threading.Tasks;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;

namespace CSMobile.Infrastructure.Services.WebApiIntegration
{
    public interface ICsApiClient
    {
        Task<AuthenticationResponseData> Authenticate(UserAuthenticationData data);
    }
}