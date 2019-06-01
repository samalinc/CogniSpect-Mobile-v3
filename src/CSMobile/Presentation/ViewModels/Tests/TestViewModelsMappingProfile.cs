using CSMobile.Domain.Models.Tests;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Presentation.ViewModels.Tests
{
    public class TestViewModelsMappingProfile : AutoMapper.Profile
    {
        public TestViewModelsMappingProfile()
        {
            CreateMap<ChooseAnswerVariant, AnswerViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .IgnoreAllOther();
            
            CreateMap<ChoosableQuestion, QuestionViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Answers, o => o.MapFrom(s => s.AnswerVariants))
                .IgnoreAllOther();
            
            CreateMap<Test, TestViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Questions, o => o.MapFrom<BaseQuestionToQuestionViewModelValueResolver>())
                .IgnoreAllOther();
            
            CreateMap<AnswerViewModel, ChooseAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .IgnoreAllOther();

            CreateMap<QuestionViewModel, ChoosableQuestion>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.AnswerVariants, o => o.MapFrom(s => s.Answers))
                .IgnoreAllOther();
            
            CreateMap<TestViewModel, Test>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions))
                .IgnoreAllOther();
        }
    }
}