using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels.Core
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected virtual ICommand Command(Func<Task> action)
        {
            return new Command(async () => await ExceptionHandler(action));
        }
        
        protected virtual ICommand Command<TArg>(Func<TArg, Task> action)
        {
            return new Command<TArg>(async arg => await ExceptionHandler(() => action(arg)));
        }
        
        private async Task ExceptionHandler(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                await OnCatchException(ex);
            }
            finally
            {
                await TryFinally();
            }
        }

        protected virtual Task OnCatchException(Exception ex)
        {
            return Task.CompletedTask;
        }
        
        protected virtual Task TryFinally()
        {
            return Task.CompletedTask;
        }
    }
}