using System;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Mvvm.LoadingDialog;
using XF.Material.Forms.UI.Dialogs;

namespace CSMobile.Presentation.Views.Services
{
    public class Loading : ILoading
    {
        public DyingWrapper<IMaterialModalPage> MaterialModalPage { get; set; }

        public string Text { get; set; }

        public Loading(string text)
        {
            Text = text;
        }

        public async Task<IDisposable> Start()
        {
            MaterialModalPage =
                new DyingWrapper<IMaterialModalPage>(await MaterialDialog.Instance.LoadingDialogAsync(Text));

            return MaterialModalPage;
        }

        public Task End()
        {
            MaterialModalPage?.Dispose();
            return Task.CompletedTask;
        }
    }
}