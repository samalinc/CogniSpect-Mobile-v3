using System.Collections.Generic;
using Autofac;
using CSMobile.Infrastructure.Common.Contexts.Session;

namespace CSMobile.Infrastructure.Common.Contexts
{
    public class ApplicationContext
    {
        public IContainer Container { get; }
        
        public UserSession UserSession { get; private set; }

        public bool IsUserAuthenticated => UserSession != null;

        public ApplicationContext(IContainer container)
        {
            Container = container;
        }

        public void BeginNewUserSession(IDictionary<string, object> data)
        {
            UserSession = UserSession.InitNewSession(Container.BeginLifetimeScope(), data);
        }

        public void EndUserSession()
        {
            UserSession?.Dispose();
            UserSession = null;
        }
    }
}