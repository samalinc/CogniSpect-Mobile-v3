using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Tests;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Tests
{
    public interface ITestsService
    {
        [ItemNotNull] Task<IEnumerable<TestListItem>> GetAvailableTests();
        [ItemNotNull] Task<Test> BeginTest(Guid testId);
        Task EndTest([NotNull] Test test);
    }
}