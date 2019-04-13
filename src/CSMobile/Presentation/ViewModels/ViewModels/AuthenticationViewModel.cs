using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Domain.Services.Authentication;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public partial class AuthenticationViewModel : BasePageViewModel
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
            bool result = await _authenticationService.Authenticate(new AuthenticationData(StudNumber, Password));
        }
    }
}