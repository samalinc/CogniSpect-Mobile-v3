using System;
using System.Collections.Generic;
using Autofac;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common.Contexts.UserSession
{
    public class UserContext : IDisposable
    {
        public ILifetimeScope Scope { get; private set; }

        private IDictionary<string, object> UserContextData { get; set; }

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

        [CanBeNull]
        public object GetUserData([NotNull] string key)
        {
            if (!UserContextData.TryGetValue(key, out var value))
            {
                return null;
            }

            return value;
        }
    }
}