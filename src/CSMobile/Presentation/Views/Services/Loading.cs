using System.Threading.Tasks;
using CSMobile.Infrastructure.Mvvm.LoadingDialog;
using XF.Material.Forms.UI.Dialogs;

namespace CSMobile.Presentation.Views.Services
{
    public class Loading : ILoading
    {
        public IMaterialModalPage MaterialModalPage { get; set; }

        public string Text { get; set; }

        public Loading(string text)
        {
            Text = text;
        }

        public async Task Start()
        {
            MaterialModalPage = await MaterialDialog.Instance.LoadingDialogAsync(Text);
        }

        public async Task End()
        {
            await MaterialModalPage.DismissAsync();
        }
    }
}