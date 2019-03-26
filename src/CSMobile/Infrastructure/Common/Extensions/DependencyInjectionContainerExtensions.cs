using Autofac;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class DependencyInjectionContainerExtensions
    {
        public static ContainerBuilder RegisterSingleAsSelf<TService>(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TService>()
                .AsSelf()
                .SingleInstance();

            return containerBuilder;
        }
        
        public static ContainerBuilder RegisterSingleAsImplementedInterfaces<TService>(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TService>()
                .AsImplementedInterfaces()
                .SingleInstance();

            return containerBuilder;
        }
    }
}