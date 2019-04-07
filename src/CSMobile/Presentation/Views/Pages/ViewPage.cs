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
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }
            
            ViewModel.OnAppearing().GetAwaiter().GetResult();
        }

        protected override void OnDisappearing()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }
            
            ViewModel.OnDisappearing().GetAwaiter().GetResult();
        }
    }
}