using System;
using Autofac;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class AutofacRegistrationExtensions
    {
        public static ContainerBuilder PerDependencyAsSelf<TConcrete>(this ContainerBuilder builder)
        {
            builder.RegisterType<TConcrete>()
                .AsSelf()
                .InstancePerDependency();

            return builder;
        }
        
        public static ContainerBuilder ScopedAsImplementedInterfaces<TConcrete>(this ContainerBuilder builder)
        {
            builder.RegisterType<TConcrete>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder;
        }
        
        public static ContainerBuilder ScopedAsSelf<TConcrete>(this ContainerBuilder builder)
        {
            builder.RegisterType<TConcrete>()
                .AsSelf()
                .InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder SingleAs<TConcrete, TAs>(this ContainerBuilder builder)
        {
            builder.RegisterType<TConcrete>()
                .As<TAs>()
                .SingleInstance();

            return builder;
        }

        public static ContainerBuilder SingleAsSelf<TConcrete>(this ContainerBuilder builder)
        {
            builder.RegisterType<TConcrete>()
                .AsSelf()
                .SingleInstance();

            return builder;
        }
        public static ContainerBuilder SingleAsImplementedInterfaces<TConcrete>(this ContainerBuilder builder)
        {
            builder.RegisterType<TConcrete>()
                .AsImplementedInterfaces()
                .SingleInstance();

            return builder;
        }

        public static ContainerBuilder ScopedFactoryAsSelf<TConcrete>(
            this ContainerBuilder builder,
            Func<IComponentContext, TConcrete> factory)
        {
            builder.Register(factory)
                .AsSelf()
                .InstancePerLifetimeScope();

            return builder;
        }
        
        public static ContainerBuilder SingleFactoryAsSelf<TConcrete>(
            this ContainerBuilder builder,
            Func<IComponentContext, TConcrete> factory)
        {
            builder.Register(factory)
                .AsSelf()
                .SingleInstance();

            return builder;
        }
        
        public static ContainerBuilder ScopedGenericAsImplementedInterfaces(this ContainerBuilder builder, Type genericType)
        {
            builder
                .RegisterGeneric(genericType)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder;
        }
        
        public static ContainerBuilder ScopedGenericAsSelf(this ContainerBuilder builder, Type genericType)
        {
            builder
                .RegisterGeneric(genericType)
                .AsSelf()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}