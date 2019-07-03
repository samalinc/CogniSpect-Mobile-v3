using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Domain.Services.Sessions;
using CSMobile.Infrastructure.Mvvm;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Sessions
{
    [UsedImplicitly]
    public partial class SessionItemsViewModel : BasePageViewModel
    {
        private readonly IViewModelsFactory _viewModelsFactory;
        private readonly ISessionService _sessionService;

        public ICommand OnRefreshTestsCommand { get; }

        public SessionItemsViewModel(
            IViewModelsFactory viewModelsFactory,
            ISessionService sessionService)
        {
            _viewModelsFactory = viewModelsFactory;
            _sessionService = sessionService;

            OnRefreshTestsCommand = Command(OnRefreshTests, this, false);
        }

        protected override Task OnFirstAppearing()
        {
            OnRefreshTestsCommand.Execute(null);
            return base.OnFirstAppearing();
        }

        public override async Task OnCommandExceptionHappenedHandler(Exception ex)
        {
            IsRefreshing = false;
            await base.OnCommandExceptionHappenedHandler(ex);
        }

        private async Task OnRefreshTests()
        {
            IsRefreshing = true;
            Sessions = _viewModelsFactory.Create<SessionListItemViewModel>(
                await _sessionService.GetSessionListItems(), this);
            IsRefreshing = false;
        }
    }
}