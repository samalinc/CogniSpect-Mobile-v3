using System.Collections.Generic;

namespace CSMobile.Domain.Models.Tests.Questions
{
    public class Question : BaseModel
    {
        public string Description { get; set; }

        public QuestionType Type { get; set; }
        
        public IList<ChooseAnswerVariant> ChooseAnswers { get; set; }
        
        public IList<MatchAnswerVariant> MatchAnswers { get; set; }
        
        public IList<SortAnswerVariant> SortAnswers { get; set; }
    }
}