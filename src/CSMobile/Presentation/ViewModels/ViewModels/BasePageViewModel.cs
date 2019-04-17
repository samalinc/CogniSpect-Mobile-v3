using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using CSMobile.Application.ViewModels.ExceptionHandling;

namespace CSMobile.Application.ViewModels.ViewModels
{
    public abstract partial class BasePageViewModel : BaseViewModel
    {
        private readonly IAppExceptionHandler _appExceptionHandler;

        protected BasePageViewModel()
        {
            _appExceptionHandler = ServiceLocator.Current.GetInstance<IAppExceptionHandler>();
        }
        
        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }
        
        protected sealed override ICommand Command(Func<Task> action)
        {
            return base.Command(async () =>
            {
                IsThinking = true;
                await action();
            });
        }
        
        protected sealed override ICommand Command<TArg>(Func<TArg, Task> action)
        {
            return base.Command<TArg>(async arg =>
            {
                IsThinking = true;
                await action(arg);
            });
        }

        protected override async Task OnCatchException(Exception ex)
        {
            await _appExceptionHandler.HandleException(ex);
        }

        protected override Task TryFinally()
        {
            IsThinking = false;
            return Task.CompletedTask;
        }
    }
}