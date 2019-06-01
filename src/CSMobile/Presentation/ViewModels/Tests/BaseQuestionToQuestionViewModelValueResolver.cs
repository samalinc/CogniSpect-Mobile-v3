using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommonServiceLocator;
using CSMobile.Domain.Models.Tests;
using JetBrains.Annotations;

namespace CSMobile.Presentation.ViewModels.Tests
{
    [UsedImplicitly]
    internal class BaseQuestionToQuestionViewModelValueResolver : IValueResolver<Test, TestViewModel, IList<QuestionViewModel>>
    {
        private readonly IMapper _mapper;

        public BaseQuestionToQuestionViewModelValueResolver()
        {
            _mapper = ServiceLocator.Current.GetInstance<IMapper>();
        }

        public IList<QuestionViewModel> Resolve(Test source, TestViewModel destination, IList<QuestionViewModel> destMember, ResolutionContext context)
        {
            return source.Questions.Select(GetQuestionViewModel).ToArray();
        }

        private QuestionViewModel GetQuestionViewModel(BaseQuestion question)
        {
            switch (question)
            {
                case ChoosableQuestion choosableQuestion:
                    return _mapper.Map<QuestionViewModel>(choosableQuestion);
                default:
                    throw new NotImplementedException($"{question.GetType()} is not supported");
            }
        }
    }
}