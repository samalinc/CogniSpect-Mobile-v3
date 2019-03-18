using System;
using Autofac;
using CSMobile.Presentation.Views.AppContext;

namespace CSMobile.Presentation.Views.Extensions
{
    internal static class ApplicationContextExtensions
    {
        public static ApplicationContextBuilder AddAutofacContainer(
            this ApplicationContextBuilder contextBuilder,
            Action<ContainerBuilder> builder)
        {
            var containerBuilder = new ContainerBuilder();
            builder(containerBuilder);

            contextBuilder.ApplicationContext.Container = containerBuilder.Build();
            return contextBuilder;
        }
    }
}