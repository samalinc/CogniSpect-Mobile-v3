using Autofac;
using CSMobile.Application.Common;
using CSMobile.Domain.Services;
using CSMobile.Infrastructure.Services;
using CSMobile.Presentation.ViewModels;
using CSMobile.Presentation.Views.AppContext;
using CSMobile.Presentation.Views.Extensions;

namespace CSMobile.Presentation.Views.Pages
{
    public partial class App : Xamarin.Forms.Application
    {
        public Application Application { get;}

        public App()
        {
            Application = new Application();
            Application.Configure();
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
