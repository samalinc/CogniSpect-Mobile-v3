using CSMobile.Presentation.ViewModels.Tests;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages.Tests
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
