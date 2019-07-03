using System;
using System.Collections.Generic;
using CSMobile.Presentation.ViewModels.Tests.Questions;

namespace CSMobile.Presentation.ViewModels.Tests
{
    public partial class TestViewModel
    {
        private QuestionViewModel _currentQuestion;
        private bool _isAnswerButtonVisible;
        private bool _isCompleteButtonVisible;
        
        public IList<QuestionViewModel> Questions { get; set; }
        
        public Guid Id { get; set; }
        
        public QuestionViewModel CurrentQuestion
        {
            get => _currentQuestion;
            set => Set(nameof(CurrentQuestion), ref _currentQuestion, value);
        }
        
        public bool IsAnswerButtonVisible
        {
            get => _isAnswerButtonVisible;
            set => Set(nameof(IsAnswerButtonVisible), ref _isAnswerButtonVisible, value);
        }
        
        public bool IsCompleteButtonVisible
        {
            get => _isCompleteButtonVisible;
            set => Set(nameof(IsCompleteButtonVisible), ref _isCompleteButtonVisible, value);
        }
    }
}