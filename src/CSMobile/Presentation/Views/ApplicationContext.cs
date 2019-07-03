using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using CommonServiceLocator;
using CSMobile.Infrastructure.Common.Contexts;
using CSMobile.Infrastructure.Common.Contexts.UserSession;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using CSMobile.Infrastructure.Services;
using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.ViewModels.Core;
using CSMobile.Presentation.ViewModels.Profile;
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
        public ILifetimeScope CurrentScope => UserContext?.Scope ?? _container;

        public bool IsUserAuthenticated => UserContext != null;

        public static async Task BuildAsync(App app)
        {
            Instance = new ApplicationContext(app);
            await Instance.RegisterServices();
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

        private async Task RegisterServices()
        {
            _container =
                ConfigureContainer(builder =>
                {
                    builder
                        .ToAssembliesRegistrator()
                        .AddCurrentDomainAssemblies(nameof(CSMobile))
                        .AddAssembly<InfrastructureServicesModule>()
                        .RegisterAssembliesModules()
                        .RegisterAutoMapper()
                        .ToContainerBuilder();

#if DEBUG
                    builder
                        .AddAutoMapperBuildCallback();
#endif
                });

            ServiceLocator.SetLocatorProvider(() =>
                _container.Resolve<IServiceLocator>(new TypedParameter(typeof(IContext), this)));

            await Task.WhenAll(
                Task.Run(ConfigureNavigation),
                Task.Run(ConfigureJsonSerializing),
                Task.Run(ConfigureLocalization));
        }

        private IContainer ConfigureContainer(Action<ContainerBuilder> action)
        {
            var containerBuilder = new ContainerBuilder();
            action(containerBuilder);

            return containerBuilder.Build();
        }

        private void ConfigureNavigation()
        {
            _navigationService = (NavigationService) ServiceLocator.Current.GetInstance<INavigationService>();

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
            // TODO: think why it doesn't work. Currently we can't change culture by this way
            AppResource.Culture = cultureResolver.GetCurrentCultureInfo();
        }
    }
}