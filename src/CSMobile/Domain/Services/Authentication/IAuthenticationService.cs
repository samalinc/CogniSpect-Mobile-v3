using System.Threading.Tasks;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;
using CSMobile.Infrastructure.Services.WebApiIntegration.Dtos;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn([NotNull] AuthenticationData authenticationData);
        Task SignOut();
    }
}