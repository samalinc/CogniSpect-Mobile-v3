using System;
using System.Globalization;
using Autofac;
using Autofac.Core;
using CommonServiceLocator;
using CSMobile.Domain.Services;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Domain.Services.Sessions;
using CSMobile.Infrastructure.Common.Contexts;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Security;
using CSMobile.Infrastructure.Services;
using CSMobile.Infrastructure.WebSockets;
using CSMobile.Infrastructure.WebSockets.Extensions;
using CSMobile.Presentation.ViewModels;
using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.ViewModels.Core;
using CSMobile.Presentation.ViewModels.Profile;
using CSMobile.Presentation.ViewModels.Services;
using CSMobile.Presentation.ViewModels.Sessions;
using CSMobile.Presentation.ViewModels.Statistics;
using CSMobile.Presentation.ViewModels.Tests;
using CSMobile.Presentation.Views.Pages.Authentication;
using CSMobile.Presentation.Views.Pages.Layouts;
using CSMobile.Presentation.Views.Pages.Profiles;
using CSMobile.Presentation.Views.Pages.Session;
using CSMobile.Presentation.Views.Pages.Statistics;
using CSMobile.Presentation.Views.Pages.Tests;
using CSMobile.Presentation.Views.Services;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CSMobile.Presentation.Views.Resources;
using Xamarin.Forms;
using XF.Material.Forms;

namespace CSMobile.Presentation.Views
{
    public partial class App : Application
    {
        private INavigationService _navigationService;
//        private IServiceLocator _serviceLocator;

        public static App Instance { get; private set; }
        public ApplicationContext Context { get; }

        /// <summary>
        /// Creates main platform independent entry class
        /// </summary>
        /// <param name="platformSpecificModule">
        /// Platform specific services module.
        /// Used to provide implementations for a specific platform 
        /// </param>
        public App([NotNull] IModule platformSpecificModule)
        {
            InitializeComponent();
            Material.Init(this, "Material.Configuration");
            Context = BuildApplication(platformSpecificModule);
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

        private ApplicationContext BuildApplication(IModule platformSpecificModule)
        {
            var context = new ApplicationContext(
                ConfigureContainer(builder => builder
                    .RegisterAutomapper(cfg => cfg
                        .RegisterProfile<TestViewModelsMappingProfile>()
                        .RegisterProfile<AuthenticationMappingProfile>()
                        .RegisterProfile<SessionsProfile>()
                        .RegisterProfile<SessionViewModelsProfile>()
                    )
                    .RegisterResponseHandlerResolver(cfg => cfg
                        .RegisterRecorder<WebSocketsHandlersRecorder>()
                    )
                    .RegisterModule(platformSpecificModule)
                    .RegisterModule<PresentationViewsModule>()
                    .RegisterModule<MvvmModule>()
                    .RegisterModule<WebSocketsModule>()
                    .RegisterModule<PresentationViewModelsModule>()
                    .RegisterModule<DomainServicesModule>()
                    .RegisterModule<InfrastructureServicesModule>()
                    .RegisterModule<InfrastructureSecurityModule>()
                ));

            ServiceLocator.SetLocatorProvider(() =>
                context.Container.Resolve<IServiceLocator>(new TypedParameter(typeof(ApplicationContext), context)));

            ConfigureNavigation();
            ConfigureJsonSerializing();
            ConfigureLocalization();

            return context;
        }

        private IContainer ConfigureContainer(Action<ContainerBuilder> action)
        {
            var containerBuilder = new ContainerBuilder();
            action(containerBuilder);

            return containerBuilder.Build();
        }

        private void ConfigureNavigation()
        {
            _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();

            _navigationService.Configure<AuthenticationViewModel, AuthenticationPage>();
            _navigationService.Configure<ProfileViewModel, ProfilePage>();
            _navigationService.Configure<SessionItemsViewModel, SessionItemsPage>();
            _navigationService.Configure<TestViewModel, TestPage>();
            _navigationService.Configure<StatisticsViewModel, StatisticsPage>();
            _navigationService.Configure<TabbedLayoutViewModel, TabbedLayoutPage>();

            MainPage = ((NavigationService) _navigationService).SetRootPage<AuthenticationViewModel>();
        }

        private void ConfigureJsonSerializing()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        private void ConfigureLocalization()
        {
            ICultureResolver cultureResolver = ServiceLocator.Current.GetInstance<ICultureResolver>();
            // TODO: think why it doesn't work. Currently we can't change culture in this way
            AppResource.Culture = cultureResolver.GetCurrentCultureInfo();
        }
    }
}