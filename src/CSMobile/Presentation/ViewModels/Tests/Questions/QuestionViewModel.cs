using System;
using System.Collections.Generic;
using CSMobile.Domain.Models.Tests;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using CSMobile.Presentation.ViewModels.Tests.Questions.Answers;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Tests.Questions
{
    [UsedImplicitly]
    public class QuestionViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }

        public string Image { get; set; }

        public QuestionType Type { get; set; }
        
        public IList<ChooseAnswerViewModel> ChooseAnswers { get; set; }
        
        public IList<MatchAnswerViewModel> MatchAnswers { get; set; }
        
        public IList<SortAnswerViewModel> SortAnswers { get; set; }
    }
}