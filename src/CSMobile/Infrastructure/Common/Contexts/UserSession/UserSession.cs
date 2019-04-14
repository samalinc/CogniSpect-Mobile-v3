using System;
using System.Collections.Generic;
using Autofac;

namespace CSMobile.Infrastructure.Common.Contexts.UserSession
{
    public class UserContext : IDisposable
    {
        public ILifetimeScope Scope { get; private set; }

        public IDictionary<string, object> UserContextData { get; set; }

        private UserContext(ILifetimeScope scope, IDictionary<string, object> data)
        {
            Scope = scope;
            UserContextData = data;
        }

        public static UserContext InitNewSession(ILifetimeScope scope, IDictionary<string, object> data)
        {
            return new UserContext(scope, data);
        }

        public void Dispose()
        {
            Scope?.Dispose();
        }
    }
}