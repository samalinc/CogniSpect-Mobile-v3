using Autofac;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Infrastructure.WebSockets.ResponseHandling;

namespace CSMobile.Infrastructure.WebSockets
{
    public class WebSocketsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .SingleAsImplementedInterfaces<ResponseHandlerExecutor>();

            builder
                .RegisterType<WebSocketSession>()
                .AsImplementedInterfaces()
                .OwnedByLifetimeScope();
        }
    }
}