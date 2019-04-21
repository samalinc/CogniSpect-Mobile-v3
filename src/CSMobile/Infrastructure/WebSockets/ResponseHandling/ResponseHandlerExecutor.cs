using System;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Json;
using CSMobile.Infrastructure.WebSockets.ResponseHandling.Core;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling
{
    internal class ResponseHandlerExecutor : IResolveHandlerExecutor
    {
        private readonly IResponseHandlerResolver _resolver;
        private readonly IJsonConverter _jsonConverter;

        public ResponseHandlerExecutor(
            IResponseHandlerResolver resolver,
            IJsonConverter jsonConverter)
        {
            _resolver = resolver;
            _jsonConverter = jsonConverter;
        }
        
        public async Task Execute(string action, object response)
        {
            IResponseHandler handler = _resolver.ResolveHandler(action);
            if (handler == null)
            {
                return;
            }
            await handler.Run(UnWrapMessage(response as string, handler.GetResponseType));
        }
        
        private object UnWrapMessage(string raw, Type type)
        {
            return _jsonConverter.Deserialize(raw, type);
        }
    }
}