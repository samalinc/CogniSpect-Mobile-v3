using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm.LoadingDialog;
using JetBrains.Annotations;

namespace CSMobile.Presentation.Views.Services
{
    [UsedImplicitly]
    internal class LoadingFactory : ILoadingFactory
    {
        private readonly ILocalizer _localizer;

        public LoadingFactory(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public ILoading Create()
        {
            return new Loading(_localizer);
        }
    }
}