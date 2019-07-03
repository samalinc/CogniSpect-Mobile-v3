using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using CSMobile.Infrastructure.Mvvm.Commands;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommandsFactory CommandsFactory => ServiceLocator.Current.GetInstance<ICommandsFactory>();

        [NotNull]
        protected ICommand Command(
            [NotNull] Func<Task> action,
            [NotNull] BasePageViewModel basePageViewModel,
            bool withGlobalLoading = true) =>
            CommandsFactory.Command(new CommandConfigs(action, basePageViewModel, withGlobalLoading));

        protected void Set<T>(string propertyName, ref T field, T newValue = default)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }

            field = newValue;
            RaisePropertyChanged(propertyName);
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = default)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("This method cannot be called with an empty string", nameof(propertyName));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}