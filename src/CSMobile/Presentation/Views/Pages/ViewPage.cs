using CSMobile.Presentation.ViewModels;
using Xamarin.Forms;

namespace CSMobile.Presentation.Views.Pages
{
    public class ViewPage<TViewModel> : ContentPage where TViewModel : IViewModel
    {
        private readonly IViewModel _viewModel;

        public ViewPage(TViewModel viewModel)
        {
            _viewModel = viewModel;

            BindingContext = viewModel;
        }
    }
}