using System;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Mvvm.LoadingDialog
{
    public interface ILoading
    {
        Task<IDisposable> Start();
        Task End();
    }
}