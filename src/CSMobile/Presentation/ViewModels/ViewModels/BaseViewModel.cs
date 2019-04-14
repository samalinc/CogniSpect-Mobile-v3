using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Infrastructure.Services.Exceptions;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public abstract partial class BaseViewModel : ViewModelBase
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
            catch (WebSocketConnectionException)
            {
                Exceptions.Add("Connection error");
            }
            catch (Exception e)
            {
                Exceptions.Add(e.ToString());
            }
        }
    }
}