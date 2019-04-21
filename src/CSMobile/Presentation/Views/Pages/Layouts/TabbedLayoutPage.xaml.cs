using CommonServiceLocator;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using CSMobile.Presentation.ViewModels.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedLayoutPage : TabbedPage, IViewPage<TabbedLayoutViewModel>
    {
        private TabbedLayoutViewModel _viewModel;

        public TabbedLayoutPage()
        {
            SetViewModel();
            InitializeComponent();
        }
        
        public void SetViewModel()
        {
            _viewModel = DesignMode.IsDesignModeEnabled 
                ? default(TabbedLayoutViewModel)
                : ServiceLocator.Current.GetInstance<TabbedLayoutViewModel>();
            BindingContext = _viewModel;
        }
    }
}