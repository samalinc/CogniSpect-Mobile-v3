using Autofac;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Services.Json;
using CSMobile.Infrastructure.Services.WebClient;

namespace CSMobile.Infrastructure.Services
{
    public class InfrastructureServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .SingleAsImplementedInterfaces<WebApiClient>()
                .SingleAsImplementedInterfaces<JsonConverter>();

            builder
                .RegisterGeneric(typeof(Injection<>))
                .AsSelf()
                .SingleInstance();
        }
    }
}