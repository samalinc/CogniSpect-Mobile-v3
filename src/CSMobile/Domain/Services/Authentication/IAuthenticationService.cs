using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        [ItemNotNull] Task<AuthenticationResult> Authenticate([NotNull] AuthenticationData authenticationData);
    }
}