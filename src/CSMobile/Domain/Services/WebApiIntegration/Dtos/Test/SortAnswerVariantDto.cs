using System;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos.Test
{
    public class SortAnswerVariantDto
    {
        public Guid Id { get; set; }

        public int ListPosition { get; set; }

        public int RightPosition { get; set; }

        public int StudentPosition { get; set; }

        public string Text { get; set; }
    }
}