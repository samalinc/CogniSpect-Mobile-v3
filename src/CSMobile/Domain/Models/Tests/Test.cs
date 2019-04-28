using System.Collections.Generic;

namespace CSMobile.Domain.Models.Tests
{
    public class Test : BaseModel
    {
        public TestStatus Status { get; set; }

        public IList<BaseQuestion> Questions { get; set; }
    }
}