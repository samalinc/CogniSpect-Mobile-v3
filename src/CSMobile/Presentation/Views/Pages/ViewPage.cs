using CommonServiceLocator;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
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
        
        protected override async void OnAppearing()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }
            
            await _viewModel.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                return;
            }
            
            await _viewModel.OnDisappearing();
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