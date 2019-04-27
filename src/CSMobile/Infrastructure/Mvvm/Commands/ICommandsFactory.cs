using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Infrastructure.Mvvm.Commands
{
    public interface ICommandsFactory
    {
        ICommand Command(Func<Task> action, BasePageViewModel pageViewModel);
    }
}