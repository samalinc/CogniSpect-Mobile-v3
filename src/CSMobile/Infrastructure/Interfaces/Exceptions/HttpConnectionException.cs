using System;

namespace CSMobile.Infrastructure.Interfaces.Exceptions
{
    public class HttpConnectionException : Exception
    {
        public HttpConnectionException(string message) : base(message)
        {
        }

        public HttpConnectionException(Exception exception) : base(string.Empty, exception)
        {
        }
    }
}