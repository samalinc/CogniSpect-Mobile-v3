using System.Threading.Tasks;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        [ItemCanBeNull]
        Task<AuthenticationResult> SignIn([NotNull] AuthenticationData authenticationData);
        Task SignOut();
    }
}