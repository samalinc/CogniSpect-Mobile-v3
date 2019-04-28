using System;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos.Test
{
    public class AnswerVariantDto
    {
        public Guid Id { get; set; }

        public bool Correct { get; set; }

        public int Position { get; set; }

        public string Text { get; set; }

        public bool StudentChose { get; set; }
    }
}