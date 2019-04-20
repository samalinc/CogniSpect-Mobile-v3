using System.ComponentModel;
using CSMobile.Application.ViewModels.ViewModels.Tests.List;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class TestItemsPageBase : ViewPage<TestItemsViewModel> { }
    
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestItemsPage : TestItemsPageBase
    {
        public TestItemsPage()
        {
            InitializeComponent();
        }
    }
}
