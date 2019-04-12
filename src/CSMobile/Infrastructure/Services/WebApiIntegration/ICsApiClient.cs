using System.Threading.Tasks;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Services.WebApiIntegration
{
    public interface ICsApiClient
    {
        [ItemNotNull] Task<AuthenticationResponseData> Authenticate([NotNull] UserAuthenticationData data);
    }
}