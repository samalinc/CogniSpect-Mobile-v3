using Autofac;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Services.Json;
using CSMobile.Infrastructure.Services.WebClient;
using CSMobile.Infrastructure.Services.WebSocketClient;

namespace CSMobile.Infrastructure.Services
{
    public class InfrastructureServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterSingleAsImplementedInterfaces<WebApiClient>()
                .RegisterSingleAsImplementedInterfaces<JsonConverter>();

            builder
                .RegisterType<DefaultWebSocketClient>()
                .AsImplementedInterfaces()
                .OwnedByLifetimeScope();

            builder
                .RegisterGeneric(typeof(Injection<>))
                .AsSelf()
                .SingleInstance();
        }
    }
}