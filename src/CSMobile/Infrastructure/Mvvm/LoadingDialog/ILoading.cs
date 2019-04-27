using System;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Mvvm.LoadingDialog
{
    public interface ILoading
    {
        Task<IDisposable> Start(string text = null);
        Task End();
    }
}