using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Presentation.Views.Pages;

namespace CSMobile.Presentation.Views
{
    public class PresentationViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterScopedAsSelf<AuthenticationPage>()
                .RegisterScopedAsSelf<ProfilePage>()
                .RegisterScopedAsSelf<TestItemsPage>()
                .RegisterScopedAsSelf<TestPage>()
                .RegisterScopedAsSelf<StatisticsPage>()
                .RegisterSingleAsImplementedInterfaces<AppSafeInjectionResolver>()
                .RegisterSingleAsImplementedInterfaces<UserContextService>()
                .RegisterSingleAsImplementedInterfaces<NavigationService>();
        }
    }
}