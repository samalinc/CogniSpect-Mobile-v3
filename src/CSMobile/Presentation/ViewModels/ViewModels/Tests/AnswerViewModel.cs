using System;

namespace CSMobile.Application.ViewModels.ViewModels.Tests
{
    public class AnswerViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        
        public string Text { get; set; }

        public bool Value { get; set; }
    }
}