using System.Threading.Tasks;
using CSMobile.Infrastructure.Common.Contexts.UserSession;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common
{
    public interface IUserContextService
    {
        Task BeginUserSession([NotNull] IHaveUserContextData data);
        Task EndUserSession();
        Task<bool> IsAuthenticated();
        [CanBeNull]
        object GetUserSessionData(string key);
    }
}