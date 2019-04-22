using System.ComponentModel;
using CSMobile.Presentation.ViewModels.Profile;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages.Profiles
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
