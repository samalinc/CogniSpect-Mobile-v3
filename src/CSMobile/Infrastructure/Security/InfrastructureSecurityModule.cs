using Autofac;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Infrastructure.Security
{
    public class InfrastructureSecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .SingleAsImplementedInterfaces<WifiPositionsService>();
        }
    }
}