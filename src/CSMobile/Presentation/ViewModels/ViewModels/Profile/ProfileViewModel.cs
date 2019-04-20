using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.ViewModels.Core;
using CSMobile.Domain.Services.Authentication;

namespace CSMobile.Application.ViewModels.ViewModels.Profile
{
    public class ProfileViewModel : BasePageViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public override string Title { get; set; } = "Profile";

        public ICommand SignOutCommand { get; }

        public ProfileViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            SignOutCommand = Command(SignOut);
        }

        private async Task SignOut()
        {
            await _authenticationService.SignOut();
        }
    }
}