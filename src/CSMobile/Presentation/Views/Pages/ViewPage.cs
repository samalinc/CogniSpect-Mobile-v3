using CommonServiceLocator;
using CSMobile.Application.ViewModels.ViewModels;
using Xamarin.Forms;

namespace CSMobile.Presentation.Views.Pages
{
    public class ViewPage<TViewModel> : ContentPage where TViewModel : BasePageViewModel
    {
        protected readonly TViewModel ViewModel;

        public ViewPage()
        {
            ViewModel = DesignMode.IsDesignModeEnabled 
                ? default(TViewModel)
                : ServiceLocator.Current.GetInstance<TViewModel>();
            BindingContext = ViewModel;
        }
        
        protected override void OnAppearing()
        {
            ViewModel.OnAppearing().GetAwaiter().GetResult();
        }

        protected override void OnDisappearing()
        {
            ViewModel.OnDisappearing().GetAwaiter().GetResult();
        }
    }
}