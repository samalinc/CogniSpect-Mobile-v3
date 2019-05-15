using System.Threading.Tasks;
using CommonServiceLocator;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.Views.Services;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace CSMobile.Presentation.Views.Pages.Startup
{
    public partial class StartupPage : ContentPage
    {
        public StartupPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Initialize();
        }

        private async Task Initialize()
        {
            App.Instance.MainPage = ((NavigationService) ServiceLocator.Current.GetInstance<INavigationService>())
                .SetRootPage<AuthenticationViewModel>();
            await RequestPermissionsIfNeeded();
        }

        private async Task RequestPermissionsIfNeeded()
        {
            if (await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location) !=
                PermissionStatus.Granted)
            {
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
            }
        }
    }
}