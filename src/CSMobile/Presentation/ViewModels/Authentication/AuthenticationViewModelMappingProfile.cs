using CSMobile.Domain.Services.Authentication;

namespace CSMobile.Presentation.ViewModels.Authentication
{
    public class AuthenticationViewModelMappingProfile : AutoMapper.Profile
    {
        public AuthenticationViewModelMappingProfile()
        {
            CreateMap<AuthenticationViewModel, AuthenticationData>();
        }
    }
}