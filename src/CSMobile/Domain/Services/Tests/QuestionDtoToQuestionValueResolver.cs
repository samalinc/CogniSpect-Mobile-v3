using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommonServiceLocator;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Enums;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Test;

namespace CSMobile.Domain.Services.Tests
{
    internal class QuestionDtoToQuestionValueResolver : IValueResolver<TestVariantDto, Test, IList<BaseQuestion>>
    {
        private readonly IMapper _mapper;

        public QuestionDtoToQuestionValueResolver()
        {
            _mapper = ServiceLocator.Current.GetInstance<IMapper>();
        }

        public IList<BaseQuestion> Resolve(TestVariantDto source, Test destination, IList<BaseQuestion> destMember, ResolutionContext context)
        {
            return source.QuestionVariants.Select(Map).ToArray();
        }

        private BaseQuestion Map(QuestionVariantDto variantDto)
        {
            switch (variantDto.Type)
            {
                case QuestionVariantType.CHOOSE:
                case QuestionVariantType.MULTICHOOSE:
                    return _mapper.Map<ChoosableQuestion>(variantDto);
                case QuestionVariantType.MATCH:
                    return _mapper.Map<MatchQuestion>(variantDto);
                case QuestionVariantType.SORT:
                    return _mapper.Map<SortQuestion>(variantDto);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}