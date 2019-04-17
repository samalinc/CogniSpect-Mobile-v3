using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common.Contexts.WebSocketSession
{
    public interface IWebSocketContext : IDisposable
    {
        Task BeginSession();
        Task SendMessage([NotNull] string action,[CanBeNull] object args);
    }
}