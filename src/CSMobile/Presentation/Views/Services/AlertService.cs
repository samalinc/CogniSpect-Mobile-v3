using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Presentation.ViewModels.Services.Dialogs.Alerts;
using XF.Material.Forms.UI.Dialogs;

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

        public async Task Alert(AlertConfigs configs)
        {
            await MaterialDialog.Instance.AlertAsync(configs.Message, configs.Title, configs.Cancel);
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