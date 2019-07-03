using System;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Tests.Questions.Answers
{
    [UsedImplicitly]
    public class AnswerViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }

        public bool Value { get; set; }
    }
}