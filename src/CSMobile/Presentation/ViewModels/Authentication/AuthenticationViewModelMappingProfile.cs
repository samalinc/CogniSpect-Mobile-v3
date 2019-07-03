using CSMobile.Domain.Services.Authentication;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Authentication
{
    [UsedImplicitly]
    internal class AuthenticationViewModelMappingProfile : AutoMapper.Profile
    {
        public AuthenticationViewModelMappingProfile()
        {
            CreateMap<AuthenticationViewModel, AuthenticationData>();
        }
    }
}