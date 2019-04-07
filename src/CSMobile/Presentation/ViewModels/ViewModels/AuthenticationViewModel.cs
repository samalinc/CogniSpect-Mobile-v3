using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Domain.Services.Authentication;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public partial class AuthenticationViewModel : BasePageViewModel, ICanThink
    {
        private readonly IAuthenticationService _authenticationService;
        
        public ICommand AuthenticateCommand { get; }

        public AuthenticationViewModel(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            
            AuthenticateCommand = Command(Authenticate);
        }

        private async Task Authenticate()
        {
            // TODO: add validation of response
            AuthenticationResult result =
                await _authenticationService.Authenticate(new AuthenticationData(StudNumber, Password));
        }
    }
}