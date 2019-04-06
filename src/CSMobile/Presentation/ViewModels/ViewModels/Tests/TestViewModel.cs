using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Application.ViewModels.Navigation;
using CSMobile.Application.ViewModels.ViewModels.Tests.List;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Tests;
using GalaSoft.MvvmLight.Messaging;

namespace CSMobile.Application.ViewModels.ViewModels.Tests
{
    public partial class TestViewModel : BasePageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ITestsService _testsService;
        private readonly IMapper _mapper;

        private int _questionNumber;
        
        public ICommand NextQuestionCommand { get; }
        public ICommand PreviousQuestionCommand { get; }
        public ICommand CompleteTestCommand { get; }

        public TestViewModel(
            INavigationService navigationService,
            ITestsService testsService,
            IMapper mapper)
        {
            _navigationService = navigationService;
            _testsService = testsService;
            _mapper = mapper;

            NextQuestionCommand = Command(NextQuestion);
            PreviousQuestionCommand = Command(PreviousQuestion);
            CompleteTestCommand = Command(CompleteTest);
            
            MessengerInstance.Register<NotificationMessage<Test>>(this, ReceiveTest);
        }

        private void ReceiveTest(NotificationMessage<Test> message)
        {
            _mapper.Map(message.Content, this);
        }

        private Task NextQuestion()
        {
            CurrentQuestion = Questions[++_questionNumber];
            if (_questionNumber == Questions.Count - 1)
            {
                IsLastQuestion = true;
            }

            IsFirstQuestion = false;
            
            return Task.CompletedTask;
        }
        
        private Task PreviousQuestion()
        {
            CurrentQuestion = Questions[--_questionNumber];
            if (_questionNumber == 0)
            {
                IsFirstQuestion = true;
            }
            IsLastQuestion = false;
            
            return Task.CompletedTask;
        }

        private async Task CompleteTest()
        {
            await _testsService.EndTest(_mapper.Map<Test>(this));
            await _navigationService.NavigateAsync<TestItemsViewModel>();
        }
    }
}