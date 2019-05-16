using Autofac;

namespace CSMobile.Infrastructure.Common.Contexts
{
    public interface IContext
    {
        ILifetimeScope CurrentScope { get; }
    }
}