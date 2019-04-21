using System.Threading.Tasks;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;
namespace CSMobile.Infrastructure.Mvvm.Navigation
{
    public interface INavigationService
    {
        Task GoToRoot();
        BasePageViewModel CurrentPageViewModel { get; }
        void Configure<TViewModel, TViewPage>() 
            where TViewModel : BasePageViewModel
            where TViewPage : IViewPage<TViewModel>;
        Task GoBack();
        Task NavigateModalAsync<TViewModel>(bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateModalAsync<TViewModel>([CanBeNull] object parameter, bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateAsync<TViewModel>(bool animated = true) where TViewModel : BasePageViewModel;
        Task NavigateAsync<TViewModel>([CanBeNull] object parameter, bool animated = true) where TViewModel : BasePageViewModel;
    }
}