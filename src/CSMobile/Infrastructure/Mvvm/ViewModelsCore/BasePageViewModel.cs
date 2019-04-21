using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonServiceLocator;
using CSMobile.Infrastructure.Common.Extensions;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.ViewModelsCore
{
    public abstract partial class BasePageViewModel : BaseViewModel
    {
        private readonly IAppExceptionHandler _appExceptionHandler;

        protected BasePageViewModel()
        {
            _appExceptionHandler = ServiceLocator.Current.GetInstance<IAppExceptionHandler>();

            OnCommandStarted += OnCommandStartedHandler;
            OnCommandEnded += OnCommandEndedHandler;
            OnCommandFinal += OnCommandFinalHandler;
            OnCommandExceptionHappened += OnCommandExceptionHappenedFinalHandler;
        }

        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearing()
        {
            return Task.CompletedTask;
        }

        public void OnCommandStartedHandler(object source, EventArgs args)
        {
            IsThinking = true;
        }

        public void OnCommandEndedHandler(object source, EventArgs args)
        {
            IsThinking = false;
        }

        public void OnCommandFinalHandler(object source, EventArgs args)
        {
            IsThinking = false;
        }

        public async void OnCommandExceptionHappenedFinalHandler(object source, Exception ex)
        {
            await _appExceptionHandler.HandleException(ex);
        }

        protected void SafeRemoveNestedViewModels([CanBeNull] [ItemNotNull] IEnumerable<BaseViewModel> viewModels)
        {
            if (viewModels.IsNullOrEmpty())
            {
                return;
            }

            foreach (var viewModel in viewModels)
            {
                viewModel.OnCommandStarted -= OnCommandStartedHandler;
                viewModel.OnCommandEnded -= OnCommandEndedHandler;
                viewModel.OnCommandFinal -= OnCommandFinalHandler;
                viewModel.OnCommandExceptionHappened -= OnCommandExceptionHappenedFinalHandler;
            }
        }
    }
}