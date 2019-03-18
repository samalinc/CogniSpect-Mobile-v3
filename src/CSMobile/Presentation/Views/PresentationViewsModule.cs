using Autofac;
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
        }
    }
}