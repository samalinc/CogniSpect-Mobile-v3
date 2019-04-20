using CommonServiceLocator;
using CSMobile.Application.ViewModels.ViewModels;
using CSMobile.Application.ViewModels.ViewModels.Core;
using Xamarin.Forms;

namespace CSMobile.Presentation.Views.Pages
{
    public class ViewPage<TViewModel> : ContentPage, IViewPage<TViewModel> where TViewModel : BasePageViewModel
    {
        private TViewModel _viewModel;

        public ViewPage()
        {
            SetViewModel();
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

        public void SetViewModel()
        {
            _viewModel = DesignMode.IsDesignModeEnabled 
                ? default(TViewModel)
                : ServiceLocator.Current.GetInstance<TViewModel>();
            BindingContext = _viewModel;
        }
    }
}