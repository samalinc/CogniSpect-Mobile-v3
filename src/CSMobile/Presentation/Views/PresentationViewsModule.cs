using Autofac;
using CSMobile.Infrastructure.Common.Contexts;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Presentation.Views.Pages.Authentication;
using CSMobile.Presentation.Views.Pages.Layouts;
using CSMobile.Presentation.Views.Pages.Profiles;
using CSMobile.Presentation.Views.Pages.Session;
using CSMobile.Presentation.Views.Pages.Statistics;
using CSMobile.Presentation.Views.Pages.Tests;
using CSMobile.Presentation.Views.Services;

namespace CSMobile.Presentation.Views
{
    public class PresentationViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterScopedAsSelf<AuthenticationPage>()
                .RegisterScopedAsSelf<ProfilePage>()
                .RegisterScopedAsSelf<SessionItemsPage>()
                .RegisterScopedAsSelf<TestPage>()
                .RegisterScopedAsSelf<StatisticsPage>()
                .RegisterScopedAsSelf<TabbedLayoutPage>();
            
            builder
                .RegisterSingleAsImplementedInterfaces<AutofacServiceLocator>()
                .RegisterSingleAsImplementedInterfaces<UserContextService>()
                .RegisterSingleAsImplementedInterfaces<WebSocketSessionService>()
                .RegisterSingleAsImplementedInterfaces<NavigationService>()
                .RegisterSingleAsImplementedInterfaces<AlertService>()
                .RegisterSingleAsImplementedInterfaces<Localizer>()
                .RegisterSingleAsImplementedInterfaces<LoadingFactory>()
                .RegisterSingleAsImplementedInterfaces<SecureStorage>();
        }
    }
}