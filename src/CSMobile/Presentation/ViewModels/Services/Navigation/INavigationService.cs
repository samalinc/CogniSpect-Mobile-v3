using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.Services.Navigation
{
    public interface INavigationService
    {
        Task GoToRoot();
        Type CurrentPageViewModel { get; }
        void Configure<TViewModel, TViewPage>() where TViewModel : ViewModelBase;
        Task GoBack();
        Task NavigateModalAsync<TViewModel>(bool animated = true) where TViewModel : ViewModelBase;
        Task NavigateModalAsync<TViewModel>(object parameter, bool animated = true) where TViewModel : ViewModelBase;
        Task NavigateAsync<TViewModel>(bool animated = true) where TViewModel : ViewModelBase;
        Task NavigateAsync<TViewModel>(object parameter, bool animated = true) where TViewModel : ViewModelBase;
    }
}