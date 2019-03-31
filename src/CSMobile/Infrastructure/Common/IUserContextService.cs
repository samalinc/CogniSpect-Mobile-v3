using System.Threading.Tasks;
using CSMobile.Infrastructure.Common.Contexts.Session;

namespace CSMobile.Infrastructure.Common
{
    public interface IUserContextService
    {
        Task BeginUserSession(IHaveUserContextData data);
        
        Task EndUserSession();
    }
}