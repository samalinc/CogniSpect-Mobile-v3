using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Services.WebSocketClient
{
    public interface IWebSocketClient : IDisposable
    {
        Task Connect();
        Task Disconnect();
        Task Send([NotNull] string action,[CanBeNull] object arg,[NotNull] Action<object> handler);
    }
}