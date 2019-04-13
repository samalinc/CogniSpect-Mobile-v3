using AutoMapper;
using CSMobile.Infrastructure.Services.WebApiIntegration.Authentication;
using CSMobile.Infrastructure.Services.WebApiIntegration.Dtos;
using CSMobile.Infrastructure.Services.WebClient;

namespace CSMobile.Domain.Services.Authentication
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<AuthenticationData, UserAuthenticationData>();

            CreateMap<WebApiResponse<AuthenticationResult>, UserContextData>()
                .ForMember(d => d.Login, o => o.MapFrom(s => s.Data.Account.Login))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Data.Account.Email))
                .ForMember(d => d.Token, o => o.MapFrom(s => s.Data.AuthToken));
        }
    }
}