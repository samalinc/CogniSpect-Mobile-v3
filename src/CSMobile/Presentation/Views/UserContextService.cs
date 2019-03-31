using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Common.Contexts.Session;

namespace CSMobile.Presentation.Views
{
    internal class UserContextService : IUserContextService
    {
        public Task BeginUserSession(IHaveUserContextData data)
        {
            App.Context.EndUserSession();
            App.Context.BeginNewUserSession(data.ToData());
            return Task.CompletedTask;
        }

        public Task EndUserSession()
        {
            App.Context.EndUserSession();
            return Task.CompletedTask;
        }
    }
}