using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using CSMobile.Infrastructure.Mvvm.Commands;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    public abstract class BaseViewModel : ViewModelBase
    {
        private ICommandsFactory CommandsFactory => ServiceLocator.Current.GetInstance<ICommandsFactory>();

        [NotNull]
        protected ICommand Command(
            [NotNull] Func<Task> action,
            [NotNull] BasePageViewModel basePageViewModel,
            bool withGlobalLoading = true) =>
            CommandsFactory.Command(new CommandConfigs(action, basePageViewModel, withGlobalLoading));
    }
}