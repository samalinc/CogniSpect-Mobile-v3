using System.Threading.Tasks;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn([NotNull] AuthenticationData authenticationData);
        Task SignOut();
        Task SafeDataForRememberMe([NotNull] AuthenticationData authenticationData, bool isShouldBeSaved);
        Task<bool> ProcessRememberMe();
    }
}