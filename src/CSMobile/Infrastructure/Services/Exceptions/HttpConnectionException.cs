using System;

namespace CSMobile.Infrastructure.Services.Exceptions
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