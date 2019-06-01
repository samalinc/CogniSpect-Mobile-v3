using System;
using System.Collections.Generic;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Enums;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos.Test
{
    public class QuestionVariantDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public QuestionVariantType Type { get; set; }

        public IEnumerable<ChooseAnswerVariantDto> ChooseAnswers { get; set; }

        public IEnumerable<MatchAnswerVariantDto> MatchAnswers { get; set; }
        
        public IEnumerable<SortAnswerVariantDto> SortAnswers { get; set; }
    }
}