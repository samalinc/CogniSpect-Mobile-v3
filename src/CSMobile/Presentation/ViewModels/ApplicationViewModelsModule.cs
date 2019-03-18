using Autofac;

namespace CSMobile.Presentation.ViewModels
{
    public class ApplicationViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}