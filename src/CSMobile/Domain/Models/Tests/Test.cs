using System.Collections.Generic;

namespace CSMobile.Domain.Models.Tests
{
    public class Test : BaseModel
    {
        public string Name { get; set; }

        public IList<Question> Questions { get; set; }
    }
}