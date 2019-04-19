using System;
using System.Threading.Tasks;

namespace CSMobile.Application.ViewModels.ExceptionHandling
{
    public interface IAppExceptionHandler
    {
        Task HandleException(Exception ex);
    }
}