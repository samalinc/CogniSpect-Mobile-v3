using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Infrastructure.Mvvm.Commands
{
    internal class CommandsFactory : ICommandsFactory
    {
        public ICommand Command(CommandConfigs configs)
        {
            Func<Task> action = configs.Action;

            action = WrapWithGlobalLoading(action, configs);
            action = WrapWithExceptionHandling(action, configs);
            action = WrapWithIsBusy(action, configs);

            return new Command(async () => await action());
        }

        private Func<Task> WrapWithGlobalLoading(Func<Task> action, CommandConfigs configs)
        {
            if (!configs.IsGlobalLoading)
            {
                return action;
            }
            
            return async () =>
            {
                using (await configs.RootPageViewModel.Loading.Start())
                {
                    await action();
                }
            };
        }

        private Func<Task> WrapWithExceptionHandling(Func<Task> action, CommandConfigs configs)
        {
            return async () => await ExceptionHandler(action, configs.RootPageViewModel);
        }
        
        private Func<Task> WrapWithIsBusy(Func<Task> action, CommandConfigs configs)
        {
            return async () =>
            {
                if (configs.RootPageViewModel.IsBusy)
                {
                    return;
                }
                
                await action();
            };
        }
        
        private async Task ExceptionHandler(Func<Task> action, BasePageViewModel pageViewModel)
        {
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