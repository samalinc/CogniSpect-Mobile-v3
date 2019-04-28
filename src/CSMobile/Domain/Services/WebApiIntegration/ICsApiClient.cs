using System.Collections.Generic;
using System.Threading.Tasks;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Interfaces.WebClient;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.WebApiIntegration
{
    public interface ICsApiClient
    {
        Task<WebApiResponse<AuthenticationResultDto>> Authenticate([NotNull] UserAuthenticationData data);
        Task<WebApiResponse<IEnumerable<TestSessionDto>>> GetTestSessionListItems();
    }
}