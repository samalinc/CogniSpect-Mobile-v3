using System.Threading.Tasks;
using CSMobile.Application.ViewModels.Alerts;
using CSMobile.Application.ViewModels.Navigation;

namespace CSMobile.Presentation.Views.Services
{
    internal class AlertService : IAlertService
    {
        private readonly INavigationService _navigationService;

        public AlertService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await ((NavigationService) _navigationService).CurrentNavigationPage.CurrentPage.DisplayAlert(title,
                message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await ((NavigationService) _navigationService).CurrentNavigationPage.CurrentPage.DisplayAlert(title,
                message, accept, cancel);
        }
    }
}