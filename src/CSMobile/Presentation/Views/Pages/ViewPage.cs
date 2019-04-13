using CommonServiceLocator;
using CSMobile.Application.ViewModels.ViewModels;
using Xamarin.Forms;

namespace CSMobile.Presentation.Views.Pages
{
    public class ViewPage<TViewModel> : ContentPage where TViewModel : BasePageViewModel
    {
        private readonly TViewModel _viewModel;

        public ViewPage()
        {
            _viewModel = DesignMode.IsDesignModeEnabled 
                ? default(TViewModel)
                : ServiceLocator.Current.GetInstance<TViewModel>();
            BindingContext = _viewModel;
        }
        
        protected override void OnAppearing()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }
            
            _viewModel.OnAppearing().GetAwaiter().GetResult();
        }

        protected override void OnDisappearing()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }
            
            _viewModel.OnDisappearing().GetAwaiter().GetResult();
        }
    }
}