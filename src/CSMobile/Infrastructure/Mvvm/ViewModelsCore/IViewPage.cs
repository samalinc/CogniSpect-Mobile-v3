namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    public interface IViewPage<TViewModel> where TViewModel : BasePageViewModel
    {
        void SetViewModel();
    }
}