using CommonServiceLocator;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Presentation.Views.Pages
{
    public class ViewPage<TViewModel> : ContentPage where TViewModel : ViewModelBase
    {
        protected readonly TViewModel ViewModel;

        public ViewPage()
        {
            ViewModel = DesignMode.IsDesignModeEnabled 
                ? default 
                : ServiceLocator.Current.GetInstance<TViewModel>();
            BindingContext = ViewModel;
        }
    }
}