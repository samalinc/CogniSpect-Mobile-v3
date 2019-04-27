using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Exceptions;
using CSMobile.Domain.Services.Mfa;
using CSMobile.Domain.Services.Tests;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;

namespace CSMobile.Domain.Services.Sessions
{
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
            var testPoints = new[] {"test1", "test2", "test3", "test4"};
            var dummyData = new List<SessionListItem>
            {
                new SessionListItem
                {
                    Name = "First Test",
                    Id = Guid.NewGuid(),
                    SecurityPoints = testPoints
                },
                new SessionListItem
                {
                    Name = "Second Test",
                    SecurityPoints = testPoints
                },
                new SessionListItem
                {
                    Name = "Third Test",
                    SecurityPoints = testPoints
                },
            };
            
            return await Task.FromResult(dummyData.AsEnumerable());
            
            // TODO: will be implemented after fixing backend issues
//            WebApiResponse<IEnumerable<TestSessionDto>> result = await _csApiClient.GetTestSessionListItems();
//
//            return _mapper.Map<IEnumerable<SessionListItem>>(result.Data);
        }

        public async Task<Test> BeginSession(SessionListItem listItem)
        {
            bool result =
                await _mfaService.IsSecondFactorPresented(_mapper.Map<SecondFactorVerificationData>(listItem));
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