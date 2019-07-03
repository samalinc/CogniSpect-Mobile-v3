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
                .ScopedAsSelf<AuthenticationPage>()
                .ScopedAsSelf<ProfilePage>()
                .ScopedAsSelf<SessionItemsPage>()
                .ScopedAsSelf<TestPage>()
                .ScopedAsSelf<StatisticsPage>()
                .ScopedAsSelf<TabbedLayoutPage>();
            
            builder
                .SingleAsImplementedInterfaces<AutofacServiceLocator>()
                .SingleAsImplementedInterfaces<UserContextService>()
                .SingleAsImplementedInterfaces<WebSocketSessionService>()
                .SingleAsImplementedInterfaces<NavigationService>()
                .SingleAsImplementedInterfaces<AlertService>()
                .SingleAsImplementedInterfaces<Localizer>()
                .SingleAsImplementedInterfaces<LoadingFactory>()
                .SingleAsImplementedInterfaces<SecureStorage>();
        }
    }
}