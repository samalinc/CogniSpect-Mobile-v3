using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using CommonServiceLocator;
using CSMobile.Domain.Services;
using CSMobile.Domain.Services.Authentication;
using CSMobile.Domain.Services.Sessions;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.Common.Contexts;
using CSMobile.Infrastructure.Common.Contexts.UserSession;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
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
using CSMobile.Presentation.Views.Resources;
using CSMobile.Presentation.Views.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CSMobile.Presentation.Views
{
    public class ApplicationContext : IContext
    {
        private IContainer _container;
        private NavigationService _navigationService;
        private readonly App _app;

        public static ApplicationContext Instance { get; private set; }
        
        public UserContext UserContext { get; private set; }
        public IWebSocketContext WebSocketContext { get; private set; }
        public ILifetimeScope CurrentScope => UserContext?.Scope ?? _container;

        public bool IsUserAuthenticated => UserContext != null;
        
        public static async Task BuildAsync(App app, IModule module)
        {
            Instance = new ApplicationContext(app);
            await Task.Run(async () => await Instance.RegisterServices(module));
        }

        private ApplicationContext(App app)
        {
            _app = app;
        }

        public async Task ChangeRootPage<TViewModel>() where TViewModel : BasePageViewModel
        {
            await Task.Run(() => _app.MainPage = _navigationService.SetRootPage<TViewModel>());
        }
        
        public void BeginNewUserSession(IDictionary<string, object> data)
        {
            UserContext = UserContext.InitNewSession(_container.BeginLifetimeScope(), data);
        }

        public void EndUserSession()
        {
            UserContext?.Dispose();
            UserContext = null;
        }

        public void BeginWebSocketSession()
        {
            WebSocketContext = ServiceLocator.Current.GetInstance<IWebSocketContext>();
            WebSocketContext.BeginSession();
        }

        public void EndWebSocketSession()
        {
            WebSocketContext?.Dispose();
            WebSocketContext = null;
        }

        private async Task RegisterServices(IModule module)
        {
            _container =
                ConfigureContainer(builder => builder
                    .RegisterAutomapper(cfg => cfg
                        .RegisterProfile<TestViewModelsMappingProfile>()
                        .RegisterProfile<TestsMappingProfile>()
                        .RegisterProfile<AuthenticationViewModelMappingProfile>()
                        .RegisterProfile<AuthenticationMappingProfile>()
                        .RegisterProfile<SessionsProfile>()
                        .RegisterProfile<SessionViewModelsProfile>()
                    )
                    .RegisterResponseHandlerResolver(cfg => cfg
                        .RegisterRecorder<WebSocketsHandlersRecorder>()
                    )
                    .RegisterModule(module)
                    .RegisterModule<PresentationViewsModule>()
                    .RegisterModule<MvvmModule>()
                    .RegisterModule<WebSocketsModule>()
                    .RegisterModule<PresentationViewModelsModule>()
                    .RegisterModule<DomainServicesModule>()
                    .RegisterModule<InfrastructureServicesModule>()
                    .RegisterModule<InfrastructureSecurityModule>()
                );

            ServiceLocator.SetLocatorProvider(() =>
                _container.Resolve<IServiceLocator>(new TypedParameter(typeof(IContext), this)));

            await Task.Run(ConfigureNavigation);
            await Task.Run(ConfigureJsonSerializing);
            await Task.Run(ConfigureLocalization);
        }

        private IContainer ConfigureContainer(Action<ContainerBuilder> action)
        {
            var containerBuilder = new ContainerBuilder();
            action(containerBuilder);

            return containerBuilder.Build();
        }

        private void ConfigureNavigation()
        {
            _navigationService = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();

            _navigationService.Configure<AuthenticationViewModel, AuthenticationPage>();
            _navigationService.Configure<ProfileViewModel, ProfilePage>();
            _navigationService.Configure<SessionItemsViewModel, SessionItemsPage>();
            _navigationService.Configure<TestViewModel, TestPage>();
            _navigationService.Configure<StatisticsViewModel, StatisticsPage>();
            _navigationService.Configure<TabbedLayoutViewModel, TabbedLayoutPage>();
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