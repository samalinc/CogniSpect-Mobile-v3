using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn([NotNull] AuthenticationData authenticationData);
        Task SignOut();
    }
}