using System.Collections.Generic;
using AutoMapper;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Models.Tests.Questions;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Enums;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Test;
using CSMobile.Infrastructure.Common.Extensions;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Tests
{
    [UsedImplicitly]
    internal class TestsMappingProfile : Profile
    {
        private readonly IReadOnlyDictionary<TestVariantStatus, TestStatus> _testStatuses =
            new Dictionary<TestVariantStatus, TestStatus>
            {
                {TestVariantStatus.STARTED, TestStatus.Started},
                {TestVariantStatus.FINISHED, TestStatus.Finished},
            };
        
        private readonly IReadOnlyDictionary<QuestionVariantType, QuestionType> _questionTypes =
            new Dictionary<QuestionVariantType, QuestionType>
            {
                {QuestionVariantType.SORT, QuestionType.Sort},
                {QuestionVariantType.MATCH, QuestionType.Match},
                {QuestionVariantType.CHOOSE, QuestionType.Choose},
                {QuestionVariantType.MULTICHOOSE, QuestionType.Multichoose},
                {QuestionVariantType.SUBSTITUTION, QuestionType.Substitution},
            };
        
        public TestsMappingProfile()
        {
            CreateMap<TestVariantDto, Test>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.QuestionVariants))
                .ForMember(d => d.Status, o => o.MapFrom(s => _testStatuses[s.TestVariantStatus]));

            CreateMap<QuestionVariantDto, Question>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Type, o => o.MapFrom(s => _questionTypes[s.Type]))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.ChooseAnswers, o => o.MapFrom(s => s.ChooseAnswers))
                .ForMember(d => d.MatchAnswers, o => o.MapFrom(s => s.MatchAnswers))
                .ForMember(d => d.SortAnswers, o => o.MapFrom(s => s.SortAnswers));

            CreateMap<ChooseAnswerVariantDto, ChooseAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Value, o => o.Ignore())
                .ForMember(d => d.Position, o => o.MapFrom(s => s.Position));
            
            CreateMap<SortAnswerVariantDto, SortAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            
            CreateMap<MatchAnswerVariantDto, MatchAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}