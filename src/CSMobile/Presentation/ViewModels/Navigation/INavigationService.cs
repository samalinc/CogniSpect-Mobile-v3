using System;
using System.Threading.Tasks;
using CSMobile.Application.ViewModels.ViewModels;
using GalaSoft.MvvmLight;

namespace CSMobile.Application.ViewModels.Navigation
{
    public interface INavigationService
    {
        Task GoToRoot();
        Type CurrentPageViewModel { get; }
        void Configure<TViewModel, TViewPage>() where TViewModel : BasePageViewModel;
        Task GoBack();
        Task NavigateModalAsync<TViewModel>(bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateModalAsync<TViewModel>(object parameter, bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateAsync<TViewModel>(bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateAsync<TViewModel>(object parameter, bool animated = true) where TViewModel : BasePageViewModel;
    }
}