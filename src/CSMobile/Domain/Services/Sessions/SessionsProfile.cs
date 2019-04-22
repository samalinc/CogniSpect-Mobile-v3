using System.Collections.Generic;
using AutoMapper;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Services.Mfa;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Domain.Services.Sessions
{
    public class SessionsProfile : Profile
    {
        private readonly IDictionary<TestSessionStatusEnum, SessionStatus> _sessionStatuses =
            new Dictionary<TestSessionStatusEnum, SessionStatus>
            {
                {TestSessionStatusEnum.DRAFT, SessionStatus.Draft},
                {TestSessionStatusEnum.STARTED, SessionStatus.Started},
                {TestSessionStatusEnum.FINISHED, SessionStatus.Finished},
            };

        public SessionsProfile()
        {
            CreateMap<TestSessionDto, SessionListItem>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.TestSessionName))
                .ForMember(d => d.Status, o => o.MapFrom(s => _sessionStatuses[s.TestSessionStatus]))
                .IgnoreAllOther();

            CreateMap<SessionListItem, SecondFactorVerificationData>()
                .ForMember(d => d.SecurityPoints, o => o.MapFrom(s => s.SecurityPoints))
                .IgnoreAllOther();
        }
    }
}