using System.Collections.Generic;

namespace CSMobile.Domain.Models.Tests
{
    public class SortQuestion : BaseQuestion
    {
        public IEnumerable<SortAnswerVariant> AnswerVariants { get; set; }
    }
}