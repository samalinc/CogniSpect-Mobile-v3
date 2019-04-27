using System.Threading.Tasks;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
namespace CSMobile.Infrastructure.Mvvm.Navigation
{
    public interface INavigationService
    {
        Task GoToRoot();
        void Configure<TViewModel, TViewPage>() 
            where TViewModel : BasePageViewModel
            where TViewPage : IViewPage<TViewModel>;
        Task GoBack();
        Task NavigateModalAsync<TViewModel>(bool animated = false) where TViewModel : BasePageViewModel;
        Task NavigateAsync<TViewModel>(bool animated = false) where TViewModel : BasePageViewModel;
    }
}