using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Infrastructure.Mvvm.Commands
{
    internal class CommandsFactory : ICommandsFactory
    {
        public ICommand Command(Func<Task> action, BasePageViewModel pageViewModel)
        {
            return new Command(async () => await ExceptionHandler(action, pageViewModel));
        } 
        
        private async Task ExceptionHandler(Func<Task> action, BasePageViewModel pageViewModel)
        {
            if (pageViewModel.IsBusy)
            {
                return;
            }
            
            try
            {
                await pageViewModel.OnCommandStartedHandler();
                await action();
                await pageViewModel.OnCommandEndedHandler();
            }
            catch (Exception ex)
            {
                await pageViewModel.OnCommandExceptionHappenedHandler(ex);
            }
            finally
            {
                await pageViewModel.OnCommandFinalHandler();
            }
        }
    }
}