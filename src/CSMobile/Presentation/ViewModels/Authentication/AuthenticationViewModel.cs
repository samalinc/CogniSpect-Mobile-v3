using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Profile;
using CSMobile.Application.ViewModels.Services.Navigation;
using CSMobile.Domain.Services.Authentication;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.Authentication
{
    public class AuthenticationViewModel : ViewModelBase, ICanThink
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;

        private string _studNumber;
        private bool _isThinking;
        private string _password;
        
        public ICommand AuthenticateCommand { get; }

        public bool IsThinking
        {
            get => _isThinking;
            set => Set(nameof(IsThinking), ref _isThinking, value);
        }
        
        public string StudNumber
        {
            get => _studNumber;
            set => Set(nameof(StudNumber), ref _studNumber, value);
        }
        
        public string Password
        {
            get => _password;
            set => Set(nameof(Password), ref _password, value);
        }


        public AuthenticationViewModel(
            INavigationService navigationService,
            IAuthenticationService authenticationService)
        {
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            AuthenticateCommand = new Command(async () => await Authenticate());
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