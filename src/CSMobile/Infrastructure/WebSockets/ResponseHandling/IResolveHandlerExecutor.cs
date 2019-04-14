using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.WebSockets.ResponseHandling
{
    public interface IResolveHandlerExecutor
    {
        Task Execute([NotNull] string action, object response);
    }
}