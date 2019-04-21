using CSMobile.Presentation.ViewModels.ViewModels.Tests;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class TestPageBase : ViewPage<TestViewModel> { }
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : TestPageBase
    {
        public TestPage()
        {
            InitializeComponent();
        }
    }
}
