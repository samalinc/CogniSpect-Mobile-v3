using System;
using System.Collections.Generic;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Presentation.ViewModels.ViewModels.Tests
{
    public class QuestionViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }

        public string Image { get; set; }
        
        public IList<AnswerViewModel> Answers { get; set; }
    }
}