using System;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Tests;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Tests
{
    public interface ITestsService
    {
        [ItemNotNull] Task<Test> GetSessionTest(Guid sessionId);
        Task EndTest([NotNull] Test test);
    }
}