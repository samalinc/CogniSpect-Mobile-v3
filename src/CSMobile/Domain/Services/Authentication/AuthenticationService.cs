using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Services.WebApiIntegration;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;
using CSMobile.Infrastructure.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Services.WebClient;

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

        public async Task<bool> Authenticate(AuthenticationData authenticationData)
        {
            WebApiResponse<AuthenticationResult> result =
                await _apiClient.Authenticate(_mapper.Map<UserAuthenticationData>(authenticationData));

            if (!result.Succeeded)
            {
                return false;
            }
            
            await _userContextService.BeginUserSession(_mapper.Map<UserContextData>(result));
            return true;
        }
    }
}