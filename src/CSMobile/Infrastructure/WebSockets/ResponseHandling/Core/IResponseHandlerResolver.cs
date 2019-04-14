using JetBrains.Annotations;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling.Core
{
    public interface IResponseHandlerResolver
    {
        [CanBeNull]
        IResponseHandler ResolveHandler([NotNull] string action);
    }
}