using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Domain.Models;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Domain.Services.WebApiIntegration.Dtos;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Tests
{
    [UsedImplicitly]
    internal class QuestionsService : IQuestionsService
    {
        private readonly ICsApiClient _csApiClient;
        private readonly IMapper _mapper;

        public QuestionsService(
            ICsApiClient csApiClient,
            IMapper mapper)
        {
            _csApiClient = csApiClient;
            _mapper = mapper;
        }

        public async Task SubmitQuestionAnswer(BaseModel answer)
        {
            await _csApiClient.SubmitAnswerForQuestion(_mapper.Map<UserAnswerModelDto>(answer));
        }
    }
}