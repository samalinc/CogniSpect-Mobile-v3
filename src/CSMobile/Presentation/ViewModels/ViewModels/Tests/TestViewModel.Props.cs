using System;
using System.Collections.Generic;

namespace CSMobile.Presentation.ViewModels.ViewModels.Tests
{
    public partial class TestViewModel
    {
        private string _name;
        private QuestionViewModel _currentQuestion;
        private bool _isPreviousButtonVisible;
        private bool _isNextButtonVisible;
        private bool _isCompleteButtonVisible;
        
        public IList<QuestionViewModel> Questions { get; set; }
        
        public Guid Id { get; set; }
                
        public string Name
        {
            get => _name;
            set => Set(nameof(Name), ref _name, value);
        }
        
        public QuestionViewModel CurrentQuestion
        {
            get => _currentQuestion;
            set => Set(nameof(CurrentQuestion), ref _currentQuestion, value);
        }
        
        public bool IsPreviousButtonVisible
        {
            get => _isPreviousButtonVisible;
            set => Set(nameof(IsPreviousButtonVisible), ref _isPreviousButtonVisible, value);
        }
        
        public bool IsNextButtonVisible
        {
            get => _isNextButtonVisible;
            set => Set(nameof(IsNextButtonVisible), ref _isNextButtonVisible, value);
        }
        
        public bool IsCompleteButtonVisible
        {
            get => _isCompleteButtonVisible;
            set => Set(nameof(IsCompleteButtonVisible), ref _isCompleteButtonVisible, value);
        }
    }
}