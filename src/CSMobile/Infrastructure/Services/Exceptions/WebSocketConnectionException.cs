using System;

namespace CSMobile.Infrastructure.Services.Exceptions
{
    public class WebSocketConnectionException : Exception
    {
        public WebSocketConnectionException(string message) : base(message)
        {
        }
    }
}