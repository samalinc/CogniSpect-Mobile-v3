using System.Collections.Generic;

namespace CSMobile.Domain.Models.Tests
{
    public class ChoosableQuestion : BaseQuestion
    {
        public IEnumerable<ChooseAnswerVariant> AnswerVariants { get; set; }
    }
}