using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Domain.Services.Authentication;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public partial class AuthenticationViewModel : BasePageViewModel, ICanThink
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;
        
        public ICommand AuthenticateCommand { get; }

        public AuthenticationViewModel(
            INavigationService navigationService,
            IAuthenticationService authenticationService)
        {
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            
            AuthenticateCommand = Command(Authenticate);
        }

        private async Task Authenticate()
        {
            AuthenticationResult result =
                await _authenticationService.Authenticate(new AuthenticationData(StudNumber, Password));
            if (result.IsAuthenticatedCorrectly)
            {
                await _navigationService.NavigateAsync<ProfileViewModel>();
//                await _navigationService.GoBack();
//                await _navigationService.GoToRoot();
            }
        }
    }
}