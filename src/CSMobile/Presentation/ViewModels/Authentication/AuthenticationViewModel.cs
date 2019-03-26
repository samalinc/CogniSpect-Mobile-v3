using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Profile;
using CSMobile.Application.ViewModels.Services.Navigation;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.Authentication
{
    public class AuthenticationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand AuthenticateCommand { get; }

        private string _studNumber;
        public string StudNumber
        {
            get => _studNumber;
            set
            {
                _studNumber = value;
                RaisePropertyChanged(nameof(StudNumber));
            }
        }

        public AuthenticationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AuthenticateCommand = new Command(async () => await Authenticate());
        }

        private async Task Authenticate()
        {
            await _navigationService.NavigateAsync<ProfileViewModel>(false);
        }
    }
}