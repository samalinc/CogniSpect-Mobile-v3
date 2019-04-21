using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Common.Contexts.UserSession;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Presentation.ViewModels.ViewModels.Authentication;
using CSMobile.Presentation.ViewModels.ViewModels.Core;

namespace CSMobile.Presentation.Views.Services
{
    internal class UserContextService : IUserContextService
    {
        private readonly INavigationService _navigationService;

        public UserContextService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public Task BeginUserSession(IHaveUserContextData data)
        {
            App.Instance.Context.EndUserSession();
            App.Instance.Context.BeginNewUserSession(data.ToData());
            App.Instance.MainPage = ((NavigationService) _navigationService).SetRootPage<TabbedLayoutViewModel>();
            
            return Task.CompletedTask;
        }

        public Task EndUserSession()
        {
            App.Instance.Context.EndUserSession();
            App.Instance.MainPage = ((NavigationService) _navigationService).SetRootPage<AuthenticationViewModel>();

            return Task.CompletedTask;
        }
        
        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(App.Instance.Context.IsUserAuthenticated);
        }

        public object GetUserSessionData(string key)
        {
            return App.Instance.Context.UserContext.UserContextData[key];
        }
    }
}