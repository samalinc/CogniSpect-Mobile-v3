using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Interfaces.WebClient;

namespace CSMobile.Domain.Services.WebApiIntegration
{
    internal class CsApiClient : ICsApiClient
    {
        private readonly IWebApiClient _webApiClient;
        private readonly IUserContextService _userContextService;
        
        private const string ApiTokenName = "Bearer token";
        private const string UserTokenName = "Token";

        public CsApiClient(
            IWebApiClient webApiClient,
            IUserContextService userContextService)
        {
            _webApiClient = webApiClient;
            _userContextService = userContextService;
        }

        public async Task<WebApiResponse<AuthenticationResult>> Authenticate(UserAuthenticationData data)
        {
            return await _webApiClient.Request<AuthenticationResult>(new WebApiRequestOptions
            {
                Body = data,
                Method = HttpMethod.Post,
                Endpoint = ApiEndpoints.Authentication
            });
        }

        public async Task<WebApiResponse<IEnumerable<TestSessionDto>>> GetTestSessionListItems()
        {
            WebApiResponse<IEnumerable<TestSessionDto>> result = await _webApiClient.GetRequest<IEnumerable<TestSessionDto>>(
                ApiEndpoints.GetStudentSessions,
                GetSecurityOptions());

            return result;
        }

        private WebApiSecurityOptions GetSecurityOptions()
        {
            var token = (string)_userContextService.GetUserSessionData(UserTokenName);
            
            if (token == null)
            {
                throw new NotImplementedException("Cannot find user security token");
            }
            return new WebApiSecurityOptions(ApiTokenName, token);
        }
    }
}