using System;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling
{
    public class ResponseHandler<TResponse> : IResponseHandler where TResponse : class
    {
        private readonly Func<TResponse, Task> _handler;

        public ResponseHandler(Func<TResponse, Task> handler)
        {
            _handler = handler;
        }

        public Type GetResponseType => typeof(TResponse);

        public async Task Run(object response) => await _handler((TResponse)response);
    }
}