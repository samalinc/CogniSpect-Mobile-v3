using System.ComponentModel;
using CSMobile.Application.ViewModels.Tests;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class TestsPageBase : ViewPage<TestsViewModel> { }
    
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestsPage : TestsPageBase
    {
        public TestsPage()
        {
            InitializeComponent();
        }
    }
}
