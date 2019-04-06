using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        protected static ICommand Command(Func<Task> action)
        {
            return new Command(async () => await action());
        }
        
        protected static ICommand Command<TArg>(Action<TArg> action)
        {
            return new Command<TArg>(action);
        }
        
        protected static ICommand Command<TArg>(Func<TArg, Task> action)
        {
            return new Command<TArg>(async arg => await action(arg));
        }
    }
}