using System.Diagnostics;
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
            await RequestPermissionsIfNeeded();
            App.Instance.MainPage = ((NavigationService) ServiceLocator.Current.GetInstance<INavigationService>())
                .SetRootPage<AuthenticationViewModel>();
            Debug.WriteLine("test");
        }

        private async Task RequestPermissionsIfNeeded()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status !=PermissionStatus.Granted)
            {
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
            }
        }
    }
}