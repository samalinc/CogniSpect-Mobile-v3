using System;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos.Test
{
    public class MatchAnswerVariantDto
    {
        public Guid Id { get; set; }

        public string Key { get; set; }

        public int KeyPosition { get; set; }

        public string StudentKey { get; set; }

        public string StudentValue { get; set; }

        public string Value { get; set; }

        public int ValuePosition { get; set; }
    }
}