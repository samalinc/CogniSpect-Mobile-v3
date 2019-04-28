namespace CSMobile.Domain.Models.Tests
{
    public class BaseQuestion : BaseModel
    {
        public string Description { get; set; }

        public QuestionType Type { get; set; }
    }
}