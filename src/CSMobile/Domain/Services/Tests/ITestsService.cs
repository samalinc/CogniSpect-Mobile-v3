using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Tests;

namespace CSMobile.Domain.Services.Tests
{
    public interface ITestsService
    {
        Task<IEnumerable<TestListItem>> GetAvailableTests();
        Task<Test> BeginTest(Guid testId);
        Task EndTest(Test test);
    }
}