using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;

namespace CSMobile.Domain.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUserContextService _userContextService;

        public AuthenticationService(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }

        public Task<AuthenticationResult> Authenticate(AuthenticationData authenticationData)
        {
            //TODO: rest logic will be implemented in future
            _userContextService.BeginUserSession(new UserContextData
            {
                Login = authenticationData.Login
            });

            return Task.FromResult(new AuthenticationResult
            {
                IsAuthenticatedCorrectly = true
            });
        }
    }
}