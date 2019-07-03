using System.Threading.Tasks;
using CSMobile.Domain.Models;
using CSMobile.Domain.Models.Tests;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Tests
{
    public interface IQuestionsService
    {
        Task SubmitQuestionAnswer([NotNull] BaseModel choosableQuestion);
    }
}