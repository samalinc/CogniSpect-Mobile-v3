using CSMobile.Application.ViewModels.ViewModels;

namespace CSMobile.Presentation.Views.Pages
{
    public interface IViewPage<TViewModel> where TViewModel : BasePageViewModel
    {
        void SetViewModel();
    }
}