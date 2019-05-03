using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Exceptions;
using CSMobile.Domain.Services.Mfa;
using CSMobile.Domain.Services.Tests;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Test;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;
using CSMobile.Infrastructure.Interfaces.WebClient;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Sessions
{
    [UsedImplicitly]
    internal class SessionService : ISessionService
    {
        private readonly ICsApiClient _csApiClient;
        private readonly IMapper _mapper;
        private readonly IMfaService _mfaService;
        private readonly IWebSocketSessionService _webSocketSessionService;
        private readonly ITestsService _testsService;

        public SessionService(
            ICsApiClient csApiClient,
            IMapper mapper,
            IMfaService mfaService,
            IWebSocketSessionService webSocketSessionService,
            ITestsService testsService)
        {
            _csApiClient = csApiClient;
            _mapper = mapper;
            _mfaService = mfaService;
            _webSocketSessionService = webSocketSessionService;
            _testsService = testsService;
        }

        public async Task<IEnumerable<SessionListItem>> GetSessionListItems()
        {
            WebApiResponse<IEnumerable<TestSessionDto>> result = await _csApiClient.GetTestSessionListItems();

            return _mapper.Map<IEnumerable<SessionListItem>>(result.Data);
        }

        public async Task<Test> BeginSession(SessionListItem listItem)
        {
            bool result =
//                await _mfaService.IsSecondFactorPresented(_mapper.Map<SecondFactorVerificationData>(listItem));
                await _mfaService.IsSecondFactorPresented(new SecondFactorVerificationData
                {
                    SecurityPoints = new[]
                    {
                        "3GWiFi_564E1O",
                        "3GWiFi_5648CC",
                        "3GWiFi_564720",
                    }
                });
            if (!result)
            {
                throw new InvalidStudentLocation();
            }

            await _webSocketSessionService.BeginSession();
            Test test = await _testsService.GetSessionTest(listItem.Id);
            return test;
        }
    }
}