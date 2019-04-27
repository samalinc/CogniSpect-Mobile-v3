using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Infrastructure.Mvvm.Commands;
using GalaSoft.MvvmLight;

namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
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