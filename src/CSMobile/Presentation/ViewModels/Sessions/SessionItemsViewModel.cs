using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Domain.Services.Sessions;
using CSMobile.Infrastructure.Common.Extensions;
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

        public override async Task OnAppearing()
        {
            if (!Sessions.IsNullOrEmpty())
            {
                return;
            }
            
            await OnRefreshTests();
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