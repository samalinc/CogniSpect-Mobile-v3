using CommonServiceLocator;
using CSMobile.Infrastructure.Common;

namespace CSMobile.Presentation.Views
{
    public class AppSafeInjectionResolver : ISafeInjectionResolver
    {
        public TService ResolveService<TService>()
        {
            return ServiceLocator.Current.GetInstance<TService>();
        }
    }
}