using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Interfaces.SecureStorage;
using CSMobile.Infrastructure.Interfaces.WebClient;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Authentication
{
    [UsedImplicitly]
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUserContextService _userContextService;
        private readonly ICsApiClient _apiClient;
        private readonly IMapper _mapper;
        private readonly ISecureStorage _secureStorage;

        public AuthenticationService(
            IUserContextService userContextService,
            ICsApiClient apiClient,
            IMapper mapper,
            ISecureStorage secureStorage)
        {
            _userContextService = userContextService;
            _apiClient = apiClient;
            _mapper = mapper;
            _secureStorage = secureStorage;
        }

        public async Task<bool> SignIn(AuthenticationData authenticationData)
        {
            WebApiResponse<AuthenticationResultDto> result =
                await _apiClient.Authenticate(_mapper.Map<UserAuthenticationData>(authenticationData));
            if (!result.Succeeded)
            {
                return false;
            }

            await _userContextService.BeginUserSession(_mapper.Map<UserContextData>(result.Data));

            return true;
        }

        public async Task SignOut()
        {
            await _userContextService.EndUserSession();
        }

        public async Task SafeDataForRememberMe(AuthenticationData authenticationData, bool isShouldBeSaved)
        {
            if (!isShouldBeSaved)
            {
                await _secureStorage.ClearStorage();
            }

            await _secureStorage.InsertOrUpdate(AuthenticationSecureStorageKeys.Login, authenticationData.Login);
            await _secureStorage.InsertOrUpdate(AuthenticationSecureStorageKeys.Password, authenticationData.Password);
        }

        public async Task<bool> ProcessRememberMe()
        {
            var login = await _secureStorage.Get(AuthenticationSecureStorageKeys.Login);

            if (string.IsNullOrEmpty(login))
            {
                return false;
            }

            var password = await _secureStorage.Get(AuthenticationSecureStorageKeys.Password);
            await SignIn(new AuthenticationData
            {
                Login = login,
                Password = password
            });
            
            return true;
        }
    }
}