using System.Collections.Generic;
using Autofac;
using CommonServiceLocator;
using CSMobile.Infrastructure.Common.Contexts.UserSession;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;

namespace CSMobile.Infrastructure.Common.Contexts
{
    public class ApplicationContext
    {
        public IContainer Container { get; }
        
        public UserContext UserContext { get; private set; }
        
        public IWebSocketContext WebSocketContext { get; private set; }

        public bool IsUserAuthenticated => UserContext != null;

        public ApplicationContext(IContainer container)
        {
            Container = container;
        }

        public void BeginNewUserSession(IDictionary<string, object> data)
        {
            UserContext = UserContext.InitNewSession(Container.BeginLifetimeScope(), data);
        }

        public void EndUserSession()
        {
            UserContext?.Dispose();
            UserContext = null;
        }
        
        public void BeginWebSocketSession()
        {
            WebSocketContext = ServiceLocator.Current.GetInstance<IWebSocketContext>();
            WebSocketContext.BeginSession();
        }

        public void EndWebSocketSession()
        {
            WebSocketContext?.Dispose();
            WebSocketContext = null;
        }
    }
}