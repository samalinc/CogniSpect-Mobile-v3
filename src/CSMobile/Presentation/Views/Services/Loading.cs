using System;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Infrastructure.Mvvm.LoadingDialog;
using XF.Material.Forms.UI.Dialogs;

namespace CSMobile.Presentation.Views.Services
{
    public class Loading : ILoading
    {
        private readonly ILocalizer _localizer;

        public DyingWrapper<IMaterialModalPage> MaterialModalPage { get; set; }

        public Loading(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public async Task<IDisposable> Start(string text)
        {
            MaterialModalPage =
                new DyingWrapper<IMaterialModalPage>(
                    await MaterialDialog.Instance.LoadingDialogAsync(text ?? _localizer["DefaultLoadingMessage"]));

            return MaterialModalPage;
        }

        public Task End()
        {
            MaterialModalPage?.Dispose();
            return Task.CompletedTask;
        }
    }
}