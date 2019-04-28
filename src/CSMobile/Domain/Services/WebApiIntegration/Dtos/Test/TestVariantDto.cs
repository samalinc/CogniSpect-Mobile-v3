using System;
using System.Collections.Generic;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Enums;

namespace CSMobile.Domain.Services.WebApiIntegration.Dtos.Test
{
    public class TestVariantDto
    {
        public Guid Id { get; set; }

        public TestVariantStatus TestVariantStatus { get; set; }

        public IEnumerable<QuestionVariantDto> QuestionVariants { get; set; }
    }
}