using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Presentation.ViewModels.Services.Alerts;

namespace CSMobile.Presentation.Views.Services
{
    internal class AlertService : IAlertService
    {
        private readonly INavigationService _navigationService;
        private readonly ILocalizer _localizer;

        public AlertService(
            INavigationService navigationService,
            ILocalizer localizer)
        {
            _navigationService = navigationService;
            _localizer = localizer;
        }

        public async Task<bool> Alert(AlertConfigs configs)
        {
            return await ((NavigationService) _navigationService).CurrentNavigationPage.CurrentPage
                .DisplayAlert(
                    configs.Title,
                    configs.Message,
                    configs.Accept,
                    configs.Cancel);
        }
        
        public async Task ErrorAlert(string message)
        {
            await Alert(new AlertConfigs
            {
                Title = _localizer["Error"],
                Message = message,
                Cancel = _localizer["Ok"]
            });
        }
    }
}