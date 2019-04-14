using System;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Services.WebSocketClient
{
    public interface IWebSocketClient : IDisposable
    {
        Task Connect();
        Task Disconnect();
        Task Send(string action, object arg, Action<object> handler);
    }
}