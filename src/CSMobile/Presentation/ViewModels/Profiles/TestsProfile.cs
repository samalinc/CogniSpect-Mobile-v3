using AutoMapper;
using CSMobile.Application.ViewModels.ViewModels.Tests;
using CSMobile.Application.ViewModels.ViewModels.Tests.List;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Tests;
using CSMobile.Infrastructure.Common.Extensions;

namespace CSMobile.Application.ViewModels.Profiles
{
    public class TestsMappingProfile : Profile
    {
        public TestsMappingProfile()
        {
            CreateMap<QuestionAnswerVariant, AnswerViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .IgnoreAllOther();
            
            CreateMap<Question, QuestionViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Image))
                .ForMember(d => d.Answers, o => o.MapFrom(s => s.Variants))
                .IgnoreAllOther();
            
            CreateMap<Test, TestViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .IgnoreAllOther();
            
            CreateMap<AnswerViewModel, QuestionAnswerVariant>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .IgnoreAllOther();

            CreateMap<QuestionViewModel, Question>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.Variants, o => o.MapFrom(s => s.Answers))
                .IgnoreAllOther();
            
            CreateMap<TestViewModel, Test>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions))
                .IgnoreAllOther();

            CreateMap<TestListItem, TestListItemViewModel>()
                .ConstructByDiContainer()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .IgnoreAllOther();

            CreateMap<TestListItemViewModel, TestListItem>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .IgnoreAllOther();
        }
    }
}