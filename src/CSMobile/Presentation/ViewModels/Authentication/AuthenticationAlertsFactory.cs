using System.Threading.Tasks;
using CSMobile.Presentation.ViewModels.Services.Alerts;

namespace CSMobile.Presentation.ViewModels.Authentication
{
    internal class AuthenticationAlertsFactory : IAuthenticationAlertsFactory
    {
        private readonly IAlertService _alertService;

        public AuthenticationAlertsFactory(IAlertService alertService)
        {
            _alertService = alertService;
        }
        
        public async Task IncorrectLoginOrPassword()
        {
            await _alertService.ErrorAlert("Incorrect login or password");
        }
    }
}