using CSMobile.Domain.Models.Sessions;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Presentation.ViewModels.Sessions
{
    public class SessionViewModelsProfile : AutoMapper.Profile
    {
        public SessionViewModelsProfile()
        {
            CreateMap<SessionListItem, SessionListItemViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .IgnoreAllOther();

            CreateMap<SessionListItemViewModel, SessionListItem>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .IgnoreAllOther();
        }
    }
}