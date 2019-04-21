using System;
using System.Windows.Input;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.Commands
{
    public class Command : ICommand
    {
        private readonly Action<object> _execute;
        
        public event EventHandler CanExecuteChanged;
        
        public Command([NotNull] Action<object> execute)
        {
            _execute = execute;
        }
        
        public Command([NotNull] Action execute)
            : this(o => execute())
        {
        }
        
        public bool CanExecute(object parameter)
        {
            //TODO: predicate for executing will be added on demand
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}