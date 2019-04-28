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
            App.Instance.Context.BeginWebSocketSession();
            return Task.CompletedTask;
        }

        public Task EndSession()
        {
            App.Instance.Context.EndWebSocketSession();
            return Task.CompletedTask;
        }

        public async Task SendMessage(string action, object message)
        {
            await App.Instance.Context.WebSocketContext.SendMessage(action, message);
        }
    }
}