using Autofac;
using CommonServiceLocator;
using CSMobile.Application.ViewModels;
using CSMobile.Application.ViewModels.Authentication;
using CSMobile.Application.ViewModels.Profile;
using CSMobile.Application.ViewModels.Services.Navigation;
using CSMobile.Application.ViewModels.Tests;
using CSMobile.Domain.Services;
using CSMobile.Infrastructure.Services;
using CSMobile.Presentation.Views.Pages;

namespace CSMobile.Presentation.Views
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            ConfigureServiceLocator();
            ConfigureNavigation();
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

        private void ConfigureServiceLocator()
        {
            var locator = new AutofacServiceLocator(builder => builder
                .RegisterModule<PresentationViewsModule>()
                .RegisterModule<ApplicationViewModelsModule>()
                .RegisterModule<DomainServicesModule>()
                .RegisterModule<InfrastructureServicesModule>()
            );
            
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        private void ConfigureNavigation()
        {
            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();

            navigationService.Configure<AuthenticationViewModel, AuthenticationPage>();
            navigationService.Configure<ProfileViewModel, ProfilePage>();
            navigationService.Configure<TestsViewModel, TestsPage>();
            
            MainPage = ((NavigationService) navigationService).SetRootPage<AuthenticationViewModel>();

        }
    }
}