using System.Threading.Tasks;

namespace CSMobile.Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> Authenticate(AuthenticationData authenticationData);
    }
}