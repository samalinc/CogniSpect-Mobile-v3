using Autofac.Core;
using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.Views.Pages.Startup;
using JetBrains.Annotations;
using XF.Material.Forms;

namespace CSMobile.Presentation.Views
{
    public partial class App
    {
        private IModule Module { get; }

        /// <summary>
        /// Creates main platform independent entry class
        /// </summary>
        /// <param name="platformSpecificModule">
        /// Platform specific services module.
        /// Used to provide implementations for a specific platform 
        /// </param>
        public App([NotNull] IModule platformSpecificModule)
        {
            MainPage = new StartupPage();
            InitializeComponent();
            Material.Init(this, "Material.Configuration");
            Module = platformSpecificModule;
        }

        protected override async void OnStart()
        {
            await ApplicationContext.BuildAsync(this, Module);
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