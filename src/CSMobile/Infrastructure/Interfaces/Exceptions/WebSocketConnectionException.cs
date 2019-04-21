using System;

namespace CSMobile.Infrastructure.Interfaces.Exceptions
{
    public class WebSocketConnectionException : Exception
    {
        public WebSocketConnectionException(string message) : base(message)
        {
        }
    }
}