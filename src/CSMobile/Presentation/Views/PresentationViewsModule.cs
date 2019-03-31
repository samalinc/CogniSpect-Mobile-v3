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
                .RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            builder
                .RegisterScopedAsSelf<AuthenticationPage>()
                .RegisterScopedAsSelf<ProfilePage>()
                .RegisterScopedAsSelf<TestsPage>()
                .RegisterSingleAsImplementedInterfaces<UserContextService>()
                .RegisterSingleAsImplementedInterfaces<NavigationService>();
        }
    }
}