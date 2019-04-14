using System;
using System.Collections.Generic;
using System.Linq;
using CommonServiceLocator;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling.Core
{
    public class ResponseHandlerResolver : IResponseHandlerResolverConfiguration, IResponseHandlerResolver
    {
        private static IDictionary<string, IResponseHandler> _handlers;
        private readonly IList<Type> _recordersTypes;
        
        public static IResponseHandlerResolverConfiguration Configuration => new ResponseHandlerResolver();

        private ResponseHandlerResolver()
        {
            _handlers = new Dictionary<string, IResponseHandler>();
            _recordersTypes = new List<Type>();
        }

        public IResponseHandlerResolverConfiguration RegisterRecorder<TRecorder>()
            where TRecorder : ResponseHandlersRecorder
        {
            _recordersTypes.Add(typeof(TRecorder));
            return this;
        }

        public ResponseHandlerResolver Build()
        {
            _handlers = _recordersTypes
                .Select(s => ServiceLocator.Current.GetInstance(s))
                .Cast<ResponseHandlersRecorder>()
                .Select(s => s.Build())
                .SelectMany(handlers => handlers.Select(s => s).ToArray())
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return this;
        }

        public IResponseHandler ResolveHandler(string action)
        {
            if (_handlers.TryGetValue(action, out IResponseHandler handler))
            {
                return handler;
            }

            return null;
        }
    }
}