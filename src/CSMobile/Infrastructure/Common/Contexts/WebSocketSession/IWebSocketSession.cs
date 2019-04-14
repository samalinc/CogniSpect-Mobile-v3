using System;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Common.Contexts.WebSocketSession
{
    public interface IWebSocketContext : IDisposable
    {
        Task BeginSession();
        Task SendMessage(string action, object args);
    }
}