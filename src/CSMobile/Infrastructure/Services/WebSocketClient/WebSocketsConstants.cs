using Quobject.EngineIoClientDotNet.Client.Transports;

namespace CSMobile.Infrastructure.Services.WebSocketClient
{
    public static class WebSocketsConstants
    {
        public static readonly int ReconnectionAttempts = 5;
        
        public static readonly string DefaultTransport = Polling.NAME;
        
        public static readonly int DefaultDelayAfterConnection = 100;
    }
}