using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quobject.Collections.Immutable;
using Quobject.SocketIoClientDotNet.Client;

namespace CSMobile.Infrastructure.Services.WebSocketClient
{
    internal class DefaultWebSocketClient : IWebSocketClient
    {
        private Socket _socket;
        private bool _isFailed;
        
        public Task Connect()
        {
            _socket = IO.Socket(AppConstants.WebSocketsUrl, new IO.Options
            {
                ReconnectionAttempts = WebSocketsConstants.ReconnectionAttempts,
                Transports = ImmutableList<string>.Empty.Add(WebSocketsConstants.DefaultTransport)
            });
            
            // need to check when attempts will end
            _socket.On(Socket.EVENT_RECONNECT_FAILED, () => _isFailed = true);

            return Task.CompletedTask;
        }

        public Task Disconnect()
        {
            Dispose();
            return Task.CompletedTask;
        }

        public Task Send(string action, object arg, Action<object> handler)
        {
            // Issue with connection because of connection is not awaitable
            // and need to wait while connection will be established
            while (_socket.Io().ReadyState != Manager.ReadyStateEnum.OPEN)
            {
                if (_isFailed)
                {
                    throw new Exception("Failed to open connection");
                }
                Thread.Sleep(WebSocketsConstants.DefaultDelayAfterConnection);
            }
            
            _socket.Emit(action, handler, WrapMessage(arg));
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _socket?.Close();
            _socket = null;
        }
        
        private string WrapMessage(object args)
        {
            return JsonConvert.SerializeObject(args);
        }
    }
}