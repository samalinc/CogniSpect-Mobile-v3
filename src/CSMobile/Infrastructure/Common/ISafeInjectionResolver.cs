namespace CSMobile.Infrastructure.Common
{
    public interface ISafeInjectionResolver
    {
        TService ResolveService<TService>();
    }
}