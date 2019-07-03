using AutoMapper;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Authentication
{
    [UsedImplicitly]
    internal class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<AuthenticationResultDto, UserContextData>()
                .ForMember(d => d.Login, o => o.MapFrom(s => s.Account.Login))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Account.Email))
                .ForMember(d => d.Token, o => o.MapFrom(s => s.AuthToken));
            
            CreateMap<AuthenticationData, LoginModelDto>();
        }
    }
}