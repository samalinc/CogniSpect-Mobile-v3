using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public class BasePageViewModel : BaseViewModel
    {
        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }
    }
}