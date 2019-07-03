using System;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;

namespace CSMobile.Presentation.ViewModels.Tests.Questions.Answers
{
    public class ChooseAnswerViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }
        
        public bool Value { get; set; }

        public int Position { get; set; }
    }
}