using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling.Core
{
    public class ResponseHandlersRecorder
    {
        private readonly IDictionary<string, IResponseHandler> _handlers;
        
        protected ResponseHandlersRecorder()
        {
            _handlers = new Dictionary<string, IResponseHandler>();
        }

        [NotNull]
        protected ResponseHandlersRecorder Register<TResponse>([NotNull] string action, Func<TResponse, Task> handler)
            where TResponse : class
        {
            _handlers.Add(action, new ResponseHandler<TResponse>(handler));

            return this;
        }

        public IDictionary<string, IResponseHandler> Build()
        {
            return _handlers;
        }
    }
}