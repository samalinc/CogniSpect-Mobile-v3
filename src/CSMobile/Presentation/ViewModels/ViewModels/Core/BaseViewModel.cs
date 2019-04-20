using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels.Core
{
    public abstract class BaseViewModel : ViewModelBase
    {
        public event EventHandler OnCommandStarted;
        public event EventHandler OnCommandEnded;
        public event EventHandler<Exception> OnCommandExceptionHappened;
        public event EventHandler OnCommandFinal;
        
        protected ICommand Command(Func<Task> action)
        {
            return new Command(async () => await ExceptionHandler(action));
        }
        
        protected ICommand Command<TArg>(Func<TArg, Task> action)
        {
            return new Command<TArg>(async arg => await ExceptionHandler(() => action(arg)));
        }
        
        private async Task ExceptionHandler(Func<Task> action)
        {
            try
            {
                OnCommandStarted?.Invoke(this, EventArgs.Empty);
                await action();
                OnCommandEnded?.Invoke(this, EventArgs.Empty);

            }
            catch (Exception ex)
            {
                OnCommandExceptionHappened?.Invoke(this, ex);
            }
            finally
            {
                OnCommandFinal?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}