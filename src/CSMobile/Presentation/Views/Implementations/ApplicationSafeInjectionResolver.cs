using Autofac;
using CSMobile.Infrastructure.Common;
using CSMobile.Presentation.ViewModels;

namespace CSMobile.Presentation.Views.Implementations
{
    [UsedImplicitly]
    internal class ApplicationSafeInjectionResolver : ISafeInjectionResolver
    {
        public TService ResolveService<TService>()
        {
            return Application.AppContext.Container.Resolve<TService>();
        }
    }
}