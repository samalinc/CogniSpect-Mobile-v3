using System.Threading.Tasks;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Presentation.ViewModels.Services.Alerts;

namespace CSMobile.Presentation.Views.Services
{
    internal class AlertService : IAlertService
    {
        private readonly INavigationService _navigationService;

        public AlertService(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
                Title = "Error",
                Message = message,
                Cancel = "OK"
            });
        }
    }
}