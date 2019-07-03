using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Common.Contexts.UserSession;
using CSMobile.Infrastructure.Interfaces.SecureStorage;
using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.ViewModels.Core;
using JetBrains.Annotations;

namespace CSMobile.Presentation.Views.Services
{
    [UsedImplicitly]
    internal class UserContextService : IUserContextService
    {
        private readonly ISecureStorage _secureStorage;

        public UserContextService(ISecureStorage secureStorage)
        {
            _secureStorage = secureStorage;
        }
        
        public async Task BeginUserSession(IHaveUserContextData data)
        {
            ApplicationContext.Instance.EndUserSession();
            ApplicationContext.Instance.BeginNewUserSession(data.ToData());
            await ApplicationContext.Instance.ChangeRootPage<TabbedLayoutViewModel>();
        }

        public async Task EndUserSession()
        {
            await _secureStorage.ClearStorage();
            ApplicationContext.Instance.EndUserSession();
            await ApplicationContext.Instance.ChangeRootPage<AuthenticationViewModel>();
        }
        
        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(ApplicationContext.Instance.IsUserAuthenticated);
        }

        public TData GetUserSessionData<TData>(string key)
        {
            return (TData)ApplicationContext.Instance.UserContext.GetUserData(key);
        }
    }
}