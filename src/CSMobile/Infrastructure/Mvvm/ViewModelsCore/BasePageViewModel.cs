using System;
using System.Threading.Tasks;
using CommonServiceLocator;
using CSMobile.Infrastructure.Mvvm.LoadingDialog;

namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    /// <summary>
    /// For creating commands in nested viewModels,
    /// use constructor argument with type <see cref="BasePageViewModel"/>
    /// and construct theirs by specified method of <see cref="IViewModelsFactory"/>
    /// </summary>
    public abstract partial class BasePageViewModel : BaseViewModel
    {
        private bool _isFirstAppearingHappened = false;
        
        private readonly IAppExceptionHandler _appExceptionHandler;
        public ILoading Loading { get; }

        protected BasePageViewModel()
        {
            _appExceptionHandler = ServiceLocator.Current.GetInstance<IAppExceptionHandler>();
            Loading = ServiceLocator.Current.GetInstance<ILoadingFactory>().Create();
        }

        protected virtual Task OnFirstAppearing()
        {
            _isFirstAppearingHappened = true;
            return Task.CompletedTask;
        }

        public virtual async Task OnAppearing()
        {
            if (!_isFirstAppearingHappened)
            {
                await OnFirstAppearing();
            }
        }

        public virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnCommandStartedHandler()
        {
            IsBusy = true;
            return Task.CompletedTask;
        }

        public virtual Task OnCommandEndedHandler()
        {
            IsBusy = false;
            return Task.CompletedTask;
        }

        public virtual Task OnCommandFinalHandler()
        {
            IsBusy = false;
            return Task.CompletedTask;
        }

        public virtual async Task OnCommandExceptionHappenedHandler(Exception ex)
        {
            await Loading.End();
            await _appExceptionHandler.HandleException(ex);
        }
    }
}