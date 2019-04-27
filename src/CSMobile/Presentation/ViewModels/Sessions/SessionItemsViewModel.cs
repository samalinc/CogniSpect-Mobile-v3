using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Domain.Services.Sessions;
using CSMobile.Infrastructure.Mvvm;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Presentation.ViewModels.Sessions
{
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

            OnRefreshTestsCommand = Command(OnRefreshTests, this);
        }

        public override async Task OnAppearing()
        {
            await OnRefreshTests();
        }

        private async Task OnRefreshTests()
        {
//            SafeRemoveNestedViewModels(Sessions);
            
            Sessions = _viewModelsFactory.Create<SessionListItemViewModel>(
                await _sessionService.GetSessionListItems(), this);
        }
    }
}