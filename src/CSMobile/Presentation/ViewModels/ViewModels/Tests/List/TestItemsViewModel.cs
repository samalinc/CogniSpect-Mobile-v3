using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.SharedEvents;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;
using GalaSoft.MvvmLight.Messaging;

namespace CSMobile.Application.ViewModels.ViewModels.Tests.List
{
    public partial class TestItemsViewModel : BasePageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ITestsService _testsService;
        private readonly IWebSocketSessionService _webSocketSessionService;

        public ICommand OnTestStartedCommand { get; }
        
        public TestItemsViewModel(
            INavigationService navigationService,
            ITestsService testsService,
            IWebSocketSessionService webSocketSessionService)
        {
            _navigationService = navigationService;
            _testsService = testsService;
            _webSocketSessionService = webSocketSessionService;
            OnTestStartedCommand = Command<TestListItem>(OnTestStarted);
        }

        public override async Task OnAppearing()
        {
            Tests = new ObservableCollection<TestListItem>(await _testsService.GetAvailableTests());
        }

        private async Task OnTestStarted(TestListItem listItem)
        {
            // TODO: refactor this after implementation server logic
            Test test = await _testsService.BeginTest(listItem.Id);
            await _webSocketSessionService.BeginSession();
            await _webSocketSessionService.SendMessage(ExternalEvents.NewMessage, listItem);
            await _navigationService.NavigateAsync<TestViewModel>();
            MessengerInstance.Send(new NotificationMessage<Test>(test, string.Empty));
        }
    }
}