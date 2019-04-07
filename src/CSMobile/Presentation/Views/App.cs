using System;
using System.Threading.Tasks;
using Autofac;
using CommonServiceLocator;
using CSMobile.Application.ViewModels;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Application.ViewModels.Profiles;
using CSMobile.Application.ViewModels.ViewModels;
using CSMobile.Application.ViewModels.ViewModels.Tests;
using CSMobile.Application.ViewModels.ViewModels.Tests.List;
using CSMobile.Domain.Services;
using CSMobile.Infrastructure.Common.Contexts;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Security;
using CSMobile.Infrastructure.Services;
using CSMobile.Presentation.Views.Pages;

namespace CSMobile.Presentation.Views
{
    public class App : Xamarin.Forms.Application
    {
        private readonly INavigationService _navigationService;
        private readonly IServiceLocator _serviceLocator;
        
        public static App Instance { get; private set; }
        public ApplicationContext Context { get; private set; }

        public App()
        {
            Context = BuildApplication();
            _serviceLocator = new AutofacServiceLocator(Context);
            ServiceLocator.SetLocatorProvider(() => _serviceLocator);
            _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            ConfigureNavigation();
            Instance = this;
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

        private ApplicationContext BuildApplication()
        {
            return new ApplicationContext(
                ConfigureContainer(builder => builder
                    .RegisterAutomapper(cfg => cfg
                        .RegisterProfile<TestsProfile>()
                    )
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
            _navigationService.Configure<TestItemsViewModel, TestItemsPage>();
            _navigationService.Configure<TestViewModel, TestPage>();
            _navigationService.Configure<StatisticsViewModel, StatisticsPage>();

            MainPage = ((NavigationService) _navigationService).SetRootPage<AuthenticationViewModel>();
        }
    }
}