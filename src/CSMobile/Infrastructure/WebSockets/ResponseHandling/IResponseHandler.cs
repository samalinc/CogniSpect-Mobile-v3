using System;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling
{
    public interface IResponseHandler
    {
        Type GetResponseType { get; }
        Task Run(object response);
    }
}