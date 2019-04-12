using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common
{
    public interface ISafeInjectionResolver
    {
        [NotNull] TService ResolveService<TService>();
    }
}