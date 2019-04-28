using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Common.Contexts.UserSession;
using CSMobile.Infrastructure.Interfaces.SecureStorage;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Presentation.ViewModels.Authentication;
using CSMobile.Presentation.ViewModels.Core;

namespace CSMobile.Presentation.Views.Services
{
    internal class UserContextService : IUserContextService
    {
        private readonly INavigationService _navigationService;
        private readonly ISecureStorage _secureStorage;

        public UserContextService(
            INavigationService navigationService,
            ISecureStorage secureStorage)
        {
            _navigationService = navigationService;
            _secureStorage = secureStorage;
        }
        
        public Task BeginUserSession(IHaveUserContextData data)
        {
            App.Instance.Context.EndUserSession();
            App.Instance.Context.BeginNewUserSession(data.ToData());
            App.Instance.MainPage = ((NavigationService) _navigationService).SetRootPage<TabbedLayoutViewModel>();
            
            return Task.CompletedTask;
        }

        public async Task EndUserSession()
        {
            await _secureStorage.ClearStorage();
            App.Instance.Context.EndUserSession();
            App.Instance.MainPage = ((NavigationService) _navigationService).SetRootPage<AuthenticationViewModel>();
        }
        
        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(App.Instance.Context.IsUserAuthenticated);
        }

        public object GetUserSessionData(string key)
        {
            return App.Instance.Context.UserContext.GetUserData(key);
        }
    }
}