using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using CSMobile.Infrastructure.Mvvm.Commands;
using GalaSoft.MvvmLight;

namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    public abstract class BaseViewModel : ViewModelBase
    {
        private ICommandsFactory CommandsFactory => ServiceLocator.Current.GetInstance<ICommandsFactory>();

        protected ICommand Command(Func<Task> action, BasePageViewModel basePageViewModel) =>
            CommandsFactory.Command(action, basePageViewModel);
    }
}