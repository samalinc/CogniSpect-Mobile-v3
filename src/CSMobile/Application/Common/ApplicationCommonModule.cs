using Autofac;

namespace CSMobile.Application.Common
{
    public class ApplicationCommonModule : Module
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