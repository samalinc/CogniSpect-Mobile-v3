using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Application.ViewModels.ViewModels.Core;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.SharedEvents;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;
using GalaSoft.MvvmLight.Messaging;

namespace CSMobile.Application.ViewModels.ViewModels.Tests.List
{
    public partial class TestListItemViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ITestsService _testsService;
        private readonly IWebSocketSessionService _webSocketSessionService;

        public ICommand OnTestStartedCommand { get; }
        
        public TestListItemViewModel(
            INavigationService navigationService,
            ITestsService testsService,
            IWebSocketSessionService webSocketSessionService)
        {
            _navigationService = navigationService;
            _testsService = testsService;
            _webSocketSessionService = webSocketSessionService;

            OnTestStartedCommand = Command(OnTestStarted);
        }
        
        private async Task OnTestStarted()
        {
            // TODO: refactor this after implementation server logic
            Test test = await _testsService.BeginTest(Id);
            await _webSocketSessionService.BeginSession();
            await _webSocketSessionService.SendMessage(ExternalEvents.NewMessage, this);
            await _navigationService.NavigateAsync<TestViewModel>();
            MessengerInstance.Send(new NotificationMessage<Test>(test, string.Empty));
        }
    }
}