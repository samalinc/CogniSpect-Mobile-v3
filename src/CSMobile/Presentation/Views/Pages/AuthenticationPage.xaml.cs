using System.ComponentModel;
using CSMobile.Application.ViewModels.ViewModels;
using CSMobile.Application.ViewModels.ViewModels.Authentication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class AuthenticationBasePage : ViewPage<AuthenticationViewModel> { }

    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : AuthenticationBasePage
    {
        public AuthenticationPage()
        {
            InitializeComponent();
        }
    }
}
