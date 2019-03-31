using System;
using System.Collections.Generic;
using Autofac;

namespace CSMobile.Infrastructure.Common.Contexts.Session
{
    public class UserSession : IDisposable
    {
        public ILifetimeScope Scope { get; private set; }

        public IDictionary<string, object> UserContextData { get; set; }

        private UserSession(ILifetimeScope scope, IDictionary<string, object> data)
        {
            Scope = scope;
            UserContextData = data;
        }

        public static UserSession InitNewSession(ILifetimeScope scope, IDictionary<string, object> data)
        {
            return new UserSession(scope, data);
        }

        public void Dispose()
        {
            Scope?.Dispose();
        }
    }
}