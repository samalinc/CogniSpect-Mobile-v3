using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Models.Tests.Questions;
using CSMobile.Infrastructure.Common.Extensions;
using CSMobile.Presentation.ViewModels.Tests.Questions;
using CSMobile.Presentation.ViewModels.Tests.Questions.Answers;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Tests
{
    [UsedImplicitly]
    internal class TestViewModelsMappingProfile : AutoMapper.Profile
    {
        public TestViewModelsMappingProfile()
        {
            CreateMap<ChooseAnswerVariant, ChooseAnswerViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .IgnoreAllOther();
            
            CreateMap<Question, QuestionViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.ChooseAnswers, o => o.MapFrom(s => s.ChooseAnswers))
                .IgnoreAllOther();
            
            CreateMap<Test, TestViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions))
                .IgnoreAllOther();
            
            CreateMap<AnswerViewModel, ChooseAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .IgnoreAllOther();
        }
    }
}