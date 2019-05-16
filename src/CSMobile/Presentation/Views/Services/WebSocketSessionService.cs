using System.Threading.Tasks;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;
using JetBrains.Annotations;

namespace CSMobile.Presentation.Views.Services
{
    [UsedImplicitly]
    internal class WebSocketSessionService : IWebSocketSessionService
    {
        public Task BeginSession()
        {
            ApplicationContext.Instance.BeginWebSocketSession();
            return Task.CompletedTask;
        }

        public Task EndSession()
        {
            ApplicationContext.Instance.EndWebSocketSession();
            return Task.CompletedTask;
        }

        public async Task SendMessage(string action, object message)
        {
            await ApplicationContext.Instance.WebSocketContext.SendMessage(action, message);
        }
    }
}