using System.Collections.Generic;

namespace CSMobile.Domain.Models.Tests
{
    public class MatchQuestion : BaseQuestion
    {
        public IEnumerable<MatchAnswerVariant> AnswerVariants { get; set; }
    }
}