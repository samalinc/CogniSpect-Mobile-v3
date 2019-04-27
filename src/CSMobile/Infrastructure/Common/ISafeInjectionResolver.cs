using System;
using Autofac.Core;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common
{
    public interface ISafeInjectionResolver
    {
        [NotNull] TService ResolveService<TService>();
        [NotNull] object ResolveService(Type type);
        [NotNull] TService ResolveService<TService>(params Parameter[] parameters);
    }
}