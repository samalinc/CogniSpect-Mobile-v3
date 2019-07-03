using System.Collections.Generic;
using CSMobile.Domain.Models.Tests.Questions;

namespace CSMobile.Domain.Models.Tests
{
    public class Test : BaseModel
    {
        public TestStatus Status { get; set; }

        public IList<Question> Questions { get; set; }
    }
}