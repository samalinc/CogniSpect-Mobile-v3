using System.Collections.Generic;

namespace CSMobile.Domain.Models.Tests
{
    public class Question : BaseModel
    {
        public string Text { get; set; }

        public string Image { get; set; }
        
        public IEnumerable<QuestionAnswerVariant> Variants { get; set; }
    }
}