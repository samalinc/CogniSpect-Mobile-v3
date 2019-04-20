using System.ComponentModel;
using CSMobile.Application.ViewModels.ViewModels.Profile;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages
{
    public class ProfilePageBase : ViewPage<ProfileViewModel> { }
 
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ProfilePageBase
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}
