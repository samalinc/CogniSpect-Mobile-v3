using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Services.Dialogs.Alerts
{
    public interface IAlertService
    {
        Task Alert([NotNull] AlertConfigs configs);
        Task ErrorAlert([NotNull] string message);
    }
}