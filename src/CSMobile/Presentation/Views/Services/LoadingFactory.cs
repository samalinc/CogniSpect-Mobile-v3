using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm.LoadingDialog;

namespace CSMobile.Presentation.Views.Services
{
    internal class LoadingFactory : ILoadingFactory
    {
        private readonly ILocalizer _localizer;

        public LoadingFactory(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public ILoading Create(string message)
        {
            return new Loading(message ?? _localizer["DefaultLoadingMessage"]);
        }
    }
}