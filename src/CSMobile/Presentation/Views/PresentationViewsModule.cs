using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Presentation.Views.Pages;
using CSMobile.Presentation.Views.Pages.Layouts;
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
                .RegisterScopedAsSelf<TabbedLayoutPage>()
                .RegisterSingleAsImplementedInterfaces<AppSafeInjectionResolver>()
                .RegisterSingleAsImplementedInterfaces<UserContextService>()
                .RegisterSingleAsImplementedInterfaces<WebSocketSessionService>()
                .RegisterSingleAsImplementedInterfaces<NavigationService>()
                .RegisterSingleAsImplementedInterfaces<AlertService>()
                .RegisterSingleAsImplementedInterfaces<Localizer>();
        }
    }
}