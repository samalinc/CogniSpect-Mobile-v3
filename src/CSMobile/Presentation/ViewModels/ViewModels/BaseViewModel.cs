using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        protected virtual ICommand Command(Func<Task> action)
        {
            return new Command(async () => await action());
        }
        
        protected virtual ICommand Command<TArg>(Action<TArg> action)
        {
            return new Command<TArg>(action);
        }
        
        protected virtual ICommand Command<TArg>(Func<TArg, Task> action)
        {
            return new Command<TArg>(async arg => await action(arg));
        }
    }
}