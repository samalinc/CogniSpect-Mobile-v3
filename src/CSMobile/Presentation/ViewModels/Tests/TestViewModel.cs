using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.Mvvm.Navigation;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Tests
{
    [UsedImplicitly]
    public partial class TestViewModel : BasePageViewModel<Test>
    {
        private readonly INavigationService _navigationService;
        private readonly ITestsService _testsService;
        private readonly IMapper _mapper;
        private readonly IQuestionsService _questionsService;

        private int _questionNumber;
        
        public ICommand AnswerTheQuestionCommand { get; }
        public ICommand CompleteTestCommand { get; }

        public TestViewModel(
            INavigationService navigationService,
            ITestsService testsService,
            IMapper mapper,
            IQuestionsService questionsService)
        {
            _navigationService = navigationService;
            _testsService = testsService;
            _mapper = mapper;
            _questionsService = questionsService;

            AnswerTheQuestionCommand = Command(AnswerTheQuestion, this, false);
            CompleteTestCommand = Command(CompleteTest, this);
        }
        
        public override Task RetrieveArgument(Test argument)
        {
            _mapper.Map(argument, this);
            _questionNumber = 0;
            CurrentQuestion = Questions[_questionNumber];
            UpdateButtonsVisibility();
            return Task.CompletedTask;
        }

        private async Task AnswerTheQuestion()
        {
//            await _questionsService.SendQuestionAnswer(_mapper.Map<ChoosableQuestion>(CurrentQuestion));
            CurrentQuestion = Questions[++_questionNumber];
            UpdateButtonsVisibility();
        }

        private void UpdateButtonsVisibility()
        {
            IsAnswerButtonVisible = _questionNumber != Questions.Count - 1;
            IsCompleteButtonVisible = !IsAnswerButtonVisible;
        }

        private async Task CompleteTest()
        {
            await _testsService.EndTest(Id);
            await _navigationService.GoToRoot();
        }
    }
}