using CSMobile.Application.ViewModels.ViewModels.Core;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public interface IViewPage<TViewModel> where TViewModel : BasePageViewModel
    {
        void SetViewModel();
    }
}