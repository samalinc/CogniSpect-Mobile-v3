using System;
using System.Collections.Generic;

namespace CSMobile.Application.ViewModels.ViewModels.Tests
{
    public partial class TestViewModel
    {
        private QuestionViewModel _currentQuestion;
        private bool _isLastQuestion;
        private bool _isFirstQuestion;
        private string _name;
        
        public IList<QuestionViewModel> Questions { get; set; }
        
        public Guid Id { get; set; }
        
        public QuestionViewModel CurrentQuestion
        {
            get => _currentQuestion;
            set => Set(nameof(CurrentQuestion), ref _currentQuestion, value);
        }
        
        public bool IsLastQuestion
        {
            get => _isLastQuestion;
            set => Set(nameof(IsLastQuestion), ref _isLastQuestion, value);
        }
        
        public bool IsFirstQuestion
        {
            get => _isLastQuestion;
            set => Set(nameof(IsFirstQuestion), ref _isFirstQuestion, value);
        }
        
        public string Name
        {
            get => _name;
            set => Set(nameof(Name), ref _name, value);
        }
    }
}