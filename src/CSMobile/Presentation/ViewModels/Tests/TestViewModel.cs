using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.Common.Contexts.WebSocketSession;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using GalaSoft.MvvmLight.Messaging;

namespace CSMobile.Presentation.ViewModels.Tests
{
    public partial class TestViewModel : BasePageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ITestsService _testsService;
        private readonly IMapper _mapper;
        private readonly IQuestionsService _questionsService;
        private readonly IWebSocketSessionService _webSocketSessionService;

        private int _questionNumber;
        
        public ICommand NextQuestionCommand { get; }
        public ICommand PreviousQuestionCommand { get; }
        public ICommand CompleteTestCommand { get; }

        public TestViewModel(
            INavigationService navigationService,
            ITestsService testsService,
            IMapper mapper,
            IQuestionsService questionsService, IWebSocketSessionService webSocketSessionService)
        {
            _navigationService = navigationService;
            _testsService = testsService;
            _mapper = mapper;
            _questionsService = questionsService;
            _webSocketSessionService = webSocketSessionService;

            NextQuestionCommand = Command(NextQuestion, this);
            PreviousQuestionCommand = Command(PreviousQuestion, this);
            CompleteTestCommand = Command(CompleteTest, this);
            
            MessengerInstance.Register<NotificationMessage<Test>>(this, ReceiveTest);
        }

        private void ReceiveTest(NotificationMessage<Test> message)
        {
            _mapper.Map(message.Content, this);
            _questionNumber = 0;
            CurrentQuestion = Questions[_questionNumber];
            UpdateButtonsVisibility();
        }

        private async Task NextQuestion()
        {
            await _questionsService.SendQuestionAnswer(_mapper.Map<Question>(CurrentQuestion));
            CurrentQuestion = Questions[++_questionNumber];
            UpdateButtonsVisibility();
        }
        
        private Task PreviousQuestion()
        {
            CurrentQuestion = Questions[--_questionNumber];
            UpdateButtonsVisibility();
            
            return Task.CompletedTask;
        }

        private void UpdateButtonsVisibility()
        {
            // TODO: Logic will be added on demand
            IsPreviousButtonVisible = false;
            IsNextButtonVisible = _questionNumber != Questions.Count - 1;
            IsCompleteButtonVisible = !IsNextButtonVisible;
        }

        private async Task CompleteTest()
        {
            await _testsService.EndTest(_mapper.Map<Test>(this));
            await _navigationService.GoToRoot();
            await _webSocketSessionService.EndSession();
        }
    }
}