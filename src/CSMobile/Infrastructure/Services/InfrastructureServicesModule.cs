using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.Services.WebApiIntegration;
using CSMobile.Infrastructure.Services.WebClient;

namespace CSMobile.Infrastructure.Services
{
    public class InfrastructureServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterScopedAsImplementedInterfaces<WebApiClient>()
                .RegisterScopedAsImplementedInterfaces<CsApiClient>();
        }
    }
}