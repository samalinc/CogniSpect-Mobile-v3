using System.Linq;
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
                .SingleInstance();
            
            builder
                .RegisterGeneric(typeof(ViewPage<>))
                .AsSelf()
                .SingleInstance();
            
            builder
                .RegisterSingleAsSelf<AuthenticationPage>()
                .RegisterSingleAsSelf<ProfilePage>()
                .RegisterSingleAsSelf<TestsPage>()
                .RegisterSingleAsImplementedInterfaces<NavigationService>();
        }
    }
}