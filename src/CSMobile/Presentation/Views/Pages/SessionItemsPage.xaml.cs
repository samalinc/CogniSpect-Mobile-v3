using System.ComponentModel;
using CSMobile.Presentation.ViewModels.Sessions;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class SessionItemsPageBase : ViewPage<SessionItemsViewModel> { }
    
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionItemsPage : SessionItemsPageBase
    {
        public SessionItemsPage()
        {
            InitializeComponent();
        }
    }
}
