using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Presentation.ViewModels.Authentication
{
    public partial class AuthenticationViewModel : BasePageViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthenticationAlertsFactory _authenticationAlertsFactory;
        
        public ICommand AuthenticateCommand { get; }

        public AuthenticationViewModel(
            IAuthenticationService authenticationService,
            IAuthenticationAlertsFactory authenticationAlertsFactory)
        {
            _authenticationService = authenticationService;
            _authenticationAlertsFactory = authenticationAlertsFactory;

            AuthenticateCommand = Command(Authenticate);
        }

        public override Task OnAppearing()
        {
            StudNumber = null;
            Password = null;
            return Task.CompletedTask;
        }

        private async Task Authenticate()
        {
            bool result = await _authenticationService.SignIn(new AuthenticationData(StudNumber, Password));
            if (!result)
            {
                await _authenticationAlertsFactory.IncorrectLoginOrPassword();
            }
        }
    }
}