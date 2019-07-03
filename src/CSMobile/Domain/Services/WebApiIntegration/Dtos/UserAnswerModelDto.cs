using System;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos
{
    public class UserAnswerModelDto
    {
        public Guid Id { get; set; }

        public int Position { get; set; }

        public string Value { get; set; }
    }
}