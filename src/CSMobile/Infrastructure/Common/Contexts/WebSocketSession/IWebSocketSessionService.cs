using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Common.Contexts.WebSocketSession
{
    public interface IWebSocketSessionService
    {
        Task BeginSession();
        Task EndSession();
        Task SendMessage(string action, object message);
    }
}