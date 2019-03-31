using System;
using Autofac;
using CommonServiceLocator;
using CSMobile.Application.ViewModels;
using CSMobile.Application.ViewModels.Authentication;
using CSMobile.Application.ViewModels.Profile;
using CSMobile.Application.ViewModels.Services.Navigation;
using CSMobile.Application.ViewModels.Tests;
using CSMobile.Domain.Services;
using CSMobile.Infrastructure.Common.Contexts;
using CSMobile.Infrastructure.Security;
using CSMobile.Infrastructure.Services;
using CSMobile.Presentation.Views.Pages;

namespace CSMobile.Presentation.Views
{
    public class App : Xamarin.Forms.Application
    {
        public static ApplicationContext Context { get; private set; }
        private readonly INavigationService _navigationService; 

        public App()
        {
            Context = BuildApplication();
            var locator = new AutofacServiceLocator(Context);
            ServiceLocator.SetLocatorProvider(() => locator);
            _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            ConfigureNavigation();
        }

        protected override void OnStart()
        {
            if (!Context.IsUserAuthenticated)
            {
                _navigationService.NavigateAsync<AuthenticationViewModel>();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private ApplicationContext BuildApplication()
        {
            return new ApplicationContext(
                ConfigureContainer(builder => builder
                    .RegisterModule<PresentationViewsModule>()
                    .RegisterModule<PresentationViewModelsModule>()
                    .RegisterModule<DomainServicesModule>()
                    .RegisterModule<InfrastructureServicesModule>()
                    .RegisterModule<InfrastructureSecurityModule>()));
        }

        private IContainer ConfigureContainer(Action<ContainerBuilder> action)
        {
            var containerBuilder = new ContainerBuilder();
            action(containerBuilder);

            return containerBuilder.Build();
        }

        private void ConfigureNavigation()
        {
            _navigationService.Configure<AuthenticationViewModel, AuthenticationPage>();
            _navigationService.Configure<ProfileViewModel, ProfilePage>();
            _navigationService.Configure<TestsViewModel, TestsPage>();
            
            MainPage = ((NavigationService) _navigationService).SetRootPage<ProfileViewModel>();
        }
    }
}