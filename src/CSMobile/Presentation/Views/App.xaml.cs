using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.Views.Pages.Startup;
using XF.Material.Forms;

namespace CSMobile.Presentation.Views
{
    public partial class App
    {
        /// <summary>
        /// Creates main platform independent entry class
        /// </summary>
        public App()
        {
            MainPage = new StartupPage();
            InitializeComponent();
            Material.Init(this, "Material.Configuration");
        }

        protected override async void OnStart()
        {
            await ApplicationContext.BuildAsync(this);
            await ApplicationContext.Instance.ChangeRootPage<AuthenticationViewModel>();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}