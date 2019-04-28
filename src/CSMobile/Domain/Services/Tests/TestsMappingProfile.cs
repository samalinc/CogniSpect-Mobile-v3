using System.Collections.Generic;
using AutoMapper;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Enums;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Test;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Domain.Services.Tests
{
    public class TestsMappingProfile : Profile
    {
        private readonly IDictionary<TestVariantStatus, TestStatus> _testStatuses =
            new Dictionary<TestVariantStatus, TestStatus>
            {
                {TestVariantStatus.STARTED, TestStatus.Started},
                {TestVariantStatus.FINISHED, TestStatus.Finished},
            };
        
        private readonly IDictionary<QuestionVariantType, QuestionType> _questionTypes =
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
                .ForMember(d => d.Questions, o => o.MapFrom<QuestionDtoToQuestionValueResolver>())
                .ForMember(d => d.Status, o => o.MapFrom(s => _testStatuses[s.TestVariantStatus]))
                .IgnoreAllOther();

            CreateMap<QuestionVariantDto, BaseQuestion>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Type, o => o.MapFrom(s => _questionTypes[s.Type]))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description));
            
            CreateMap<QuestionVariantDto, ChoosableQuestion>()
                .IncludeBase<QuestionVariantDto, BaseQuestion>()
                .ForMember(d => d.AnswerVariants, o => o.MapFrom(s => s.Answers))
                .IgnoreAllOther();
            
            CreateMap<QuestionVariantDto, MatchQuestion>()
                .IncludeBase<QuestionVariantDto, BaseQuestion>()
                .ForMember(d => d.AnswerVariants, o => o.MapFrom(s => s.Answers))
                .IgnoreAllOther();
            
            CreateMap<QuestionVariantDto, SortQuestion>()
                .IncludeBase<QuestionVariantDto, BaseQuestion>()
                .ForMember(d => d.AnswerVariants, o => o.MapFrom(s => s.Answers))
                .IgnoreAllOther();

            CreateMap<AnswerVariantDto, AnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Position, o => o.MapFrom(s => s.Position))
                .IgnoreAllOther();
            
            CreateMap<SortAnswerVariantDto, SortAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .IgnoreAllOther();
            
            CreateMap<MatchAnswerVariantDto, MatchAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .IgnoreAllOther();
        }
    }
}