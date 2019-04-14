using System;
using System.Threading.Tasks;
using CSMobile.Infrastructure.WebSockets.ResponseHandling.Core;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling
{
    internal class ResponseHandlerExecutor : IResolveHandlerExecutor
    {
        private readonly IResponseHandlerResolver _resolver;

        public ResponseHandlerExecutor(IResponseHandlerResolver resolver)
        {
            _resolver = resolver;
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
            return JsonConvert.DeserializeObject(raw, type);
        }
    }
}