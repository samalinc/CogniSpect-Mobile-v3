using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Profile
{
    [UsedImplicitly]
    public class ProfileViewModel : BasePageViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public ICommand SignOutCommand { get; }

        public ProfileViewModel(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            SignOutCommand = Command(SignOut, this);
        }

        private async Task SignOut()
        {
            await _authenticationService.SignOut();
        }
    }
}