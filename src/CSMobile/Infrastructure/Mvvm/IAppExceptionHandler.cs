using System;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Mvvm
{
    public interface IAppExceptionHandler
    {
        Task HandleException(Exception ex);
    }
}