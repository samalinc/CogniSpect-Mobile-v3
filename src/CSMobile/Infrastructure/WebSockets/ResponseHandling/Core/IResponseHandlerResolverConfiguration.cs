namespace CSMobile.Infrastructure.WebSockets.ResponseHandling.Core
{
    public interface IResponseHandlerResolverConfiguration
    {
        IResponseHandlerResolverConfiguration RegisterRecorder<TRecorder>() where TRecorder : ResponseHandlersRecorder;
        ResponseHandlerResolver Build();
    }
}