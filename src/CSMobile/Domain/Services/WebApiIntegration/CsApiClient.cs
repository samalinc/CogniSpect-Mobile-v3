using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Test;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Interfaces.WebClient;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.WebApiIntegration
{
    [UsedImplicitly]
    internal class CsApiClient : ICsApiClient
    {
        private readonly IWebApiClient _webApiClient;
        private readonly IUserContextService _userContextService;
        
        private const string ApiTokenName = "Bearer";
        private const string UserTokenName = "Token";

        public CsApiClient(
            IWebApiClient webApiClient,
            IUserContextService userContextService)
        {
            _webApiClient = webApiClient;
            _userContextService = userContextService;
        }

        public async Task<WebApiResponse<AuthenticationResultDto>> Authenticate(UserAuthenticationData data)
        {
            return await _webApiClient.Request<AuthenticationResultDto>(new WebApiRequestOptions
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
        
        public async Task<WebApiResponse<TestVariantDto>> GetTestVariant(Guid sessionId)
        {
            WebApiResponse<TestVariantDto> result = await _webApiClient.Request<TestVariantDto>(
                new WebApiRequestOptions
                {
                    Method = HttpMethod.Get,
                    Endpoint = string.Format(ApiEndpoints.GetTestVariantTemplate, sessionId),
                    SecurityToken = GetSecurityOptions()
                });
 
            return result;
        }
        
        public async Task<WebApiResponse> FinishTestVariant(Guid testId)
        {
            WebApiResponse<TestVariantDto> result = await _webApiClient.Request<TestVariantDto>(
                new WebApiRequestOptions
                {
                    Method = HttpMethod.Put,
                    Endpoint = string.Format(ApiEndpoints.GetTestVariantTemplate, testId),
                    SecurityToken = GetSecurityOptions()
                });
 
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