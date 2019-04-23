using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Mvvm.LoadingDialog
{
    public interface ILoading
    {
        Task Start();
        Task End();
    }
}