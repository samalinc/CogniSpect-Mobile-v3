using Autofac;
using AutoMapper;
using CSMobile.Infrastructure.Common.Autofac;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class AutofacContainerBuilderExtensions
    {
        public static AssembliesRecorder ToAssembliesRegistrator(this ContainerBuilder builder)
        {
            return new AssembliesRecorder(builder);
        }
        
        public static ContainerBuilder AddAutoMapperBuildCallback(this ContainerBuilder builder)
        {
            builder.RegisterBuildCallback(container =>
                container.Resolve<MapperConfiguration>().AssertConfigurationIsValid());

            return builder;
        }
    }
}