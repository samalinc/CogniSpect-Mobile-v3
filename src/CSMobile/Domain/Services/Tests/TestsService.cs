using System;
using System.Threading.Tasks;
using AutoMapper;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.WebApiIntegration;
using CSMobile.Domain.Services.WebApiIntegration.Dtos.Test;
using CSMobile.Infrastructure.Interfaces.WebClient;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Tests
{
    [UsedImplicitly]
    internal class TestsService : ITestsService
    {
        private readonly ICsApiClient _csApiClient;
        private readonly IMapper _mapper;

        public TestsService(
            ICsApiClient csApiClient,
            IMapper mapper)
        {
            _csApiClient = csApiClient;
            _mapper = mapper;
        }

        public async Task<Test> GetSessionTest(Guid sessionId)
        {
            WebApiResponse<TestVariantDto> result = await _csApiClient.GetTestVariant(sessionId);

            return _mapper.Map<Test>(result.Data);
        }

        public async Task EndTest(Test test)
        {
            await Task.CompletedTask;
        }
    }
}