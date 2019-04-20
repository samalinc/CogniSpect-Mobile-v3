namespace CSMobile.Application.ViewModels.ViewModels.Core
{
    public interface IViewPage<TViewModel> where TViewModel : BasePageViewModel
    {
        void SetViewModel();
    }
}