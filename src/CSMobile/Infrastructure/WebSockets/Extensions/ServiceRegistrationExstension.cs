using System;
using Autofac;
using CSMobile.Infrastructure.WebSockets.ResponseHandling;
using CSMobile.Infrastructure.WebSockets.ResponseHandling.Core;

namespace CSMobile.Infrastructure.WebSockets.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static ContainerBuilder RegisterResponseHandlerResolver(this ContainerBuilder builder,
            Action<IResponseHandlerResolverConfiguration> action)
        {
            var resolverBuilder = ResponseHandlerResolver.Configuration;
            action(resolverBuilder);
            
            builder
                .Register(context => resolverBuilder.Build())
                .As<IResponseHandlerResolver>()
                .SingleInstance();

            return builder;
        }
    }
}