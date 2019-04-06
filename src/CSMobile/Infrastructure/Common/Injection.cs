namespace CSMobile.Infrastructure.Common
{
    public class Injection<TService>
    {
        private readonly ISafeInjectionResolver _safeInjectionResolver;

        public Injection(ISafeInjectionResolver safeInjectionResolver)
        {
            _safeInjectionResolver = safeInjectionResolver;
        }

        public TService Value => _safeInjectionResolver.ResolveService<TService>();
    }
}