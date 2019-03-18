using Autofac;

namespace CSMobile.Infrastructure.Services
{
    public class InfrastructureServicesModule : Module
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