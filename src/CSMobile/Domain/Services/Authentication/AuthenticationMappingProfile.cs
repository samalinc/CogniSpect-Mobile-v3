using AutoMapper;
using CSMobile.Domain.Services.WebApiIntegration.Authentication;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;

namespace CSMobile.Domain.Services.Authentication
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<AuthenticationData, UserAuthenticationData>();

            CreateMap<AuthenticationResult, UserContextData>()
                .ForMember(d => d.Login, o => o.MapFrom(s => s.Account.Login))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Account.Email))
                .ForMember(d => d.Token, o => o.MapFrom(s => s.AuthToken));
        }
    }
}