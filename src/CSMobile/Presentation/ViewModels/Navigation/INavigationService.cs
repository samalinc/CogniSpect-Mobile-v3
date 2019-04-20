using System;
using System.Threading.Tasks;
using CSMobile.Application.ViewModels.ViewModels;
using CSMobile.Application.ViewModels.ViewModels.Core;
using JetBrains.Annotations;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.Navigation
{
    public interface INavigationService
    {
        Task GoToRoot();
        Type CurrentPageViewModel { get; }
        void Configure<TViewModel, TViewPage>() 
            where TViewModel : BasePageViewModel
            where TViewPage : IViewPage<TViewModel>;
        Task GoBack();
        Task NavigateModalAsync<TViewModel>(bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateModalAsync<TViewModel>([CanBeNull] object parameter, bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateAsync<TViewModel>(bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateAsync<TViewModel>([CanBeNull] object parameter, bool animated = true) where TViewModel : BasePageViewModel;
        Page SetRootPage<TViewModel>() where TViewModel : BasePageViewModel;
    }
}