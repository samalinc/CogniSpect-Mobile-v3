namespace CSMobile.Domain.Models.Tests
{
    public class ChooseAnswerVariant : BaseModel
    {
        public int Position { get; set; }
        
        public string Text { get; set; }

        public bool Value { get; set; }
    }
}