using System.Threading.Tasks;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;
using CSMobile.Infrastructure.Interfaces.WebSocketClient;
using CSMobile.Infrastructure.WebSockets.ResponseHandling;

namespace CSMobile.Infrastructure.WebSockets
{
    internal class WebSocketSession : IWebSocketContext
    {
        private readonly IResolveHandlerExecutor _handlerExecutor;
        private readonly IWebSocketClient _webSocketClient;

        public WebSocketSession(
            IResolveHandlerExecutor executor,
            IWebSocketClient webSocketClient)
        {
            _handlerExecutor = executor;
            _webSocketClient = webSocketClient;
        }
        
        public async Task BeginSession()
        {
            await _webSocketClient.Connect();
        }

        public async Task SendMessage(string action, object args)
        {
            await _webSocketClient.Send(action, args, async arg => await _handlerExecutor.Execute(action, arg));
        }

        public void Dispose()
        {
            _webSocketClient?.Dispose();
        }
    }
}