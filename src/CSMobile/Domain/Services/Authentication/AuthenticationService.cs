using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Interfaces.WebClient;

namespace CSMobile.Domain.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUserContextService _userContextService;
        private readonly ICsApiClient _apiClient;
        private readonly IMapper _mapper;

        public AuthenticationService(
            IUserContextService userContextService,
            ICsApiClient apiClient,
            IMapper mapper)
        {
            _userContextService = userContextService;
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<AuthenticationResult> SignIn(AuthenticationData authenticationData)
        {
            WebApiResponse<AuthenticationResult> result =
                await _apiClient.Authenticate(_mapper.Map<UserAuthenticationData>(authenticationData));

            return result.Data;
        }

        public async Task SignOut()
        {
            await _userContextService.EndUserSession();
        }
    }
}