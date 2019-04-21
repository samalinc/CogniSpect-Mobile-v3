using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Interfaces.WebClient;

namespace CSMobile.Domain.Services.Sessions
{
    internal class SessionService : ISessionService
    {
        private readonly ICsApiClient _csApiClient;
        private readonly IMapper _mapper;

        public SessionService(
            ICsApiClient csApiClient,
            IMapper mapper)
        {
            _csApiClient = csApiClient;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<SessionListItem>> GetSessionListItems()
        {
            var dummyData = new List<SessionListItem>
            {
                new SessionListItem
                {
                    Name = "First Test",
                    Id = Guid.NewGuid()
                },
                new SessionListItem
                {
                    Name = "Second Test"
                },
                new SessionListItem
                {
                    Name = "Third Test"
                },
            };
            
            return dummyData.AsEnumerable();
            
            // TODO: will be implemented after fixing backend issues
//            WebApiResponse<IEnumerable<TestSessionDto>> result = await _csApiClient.GetTestSessionListItems();
//
//            return _mapper.Map<IEnumerable<SessionListItem>>(result.Data);
        }
    }
}