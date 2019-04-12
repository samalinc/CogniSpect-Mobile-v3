using System.Threading.Tasks;
using CSMobile.Domain.Models.Tests;

namespace CSMobile.Domain.Services.Tests
{
    internal class QuestionsService : IQuestionsService
    {
        public Task SendQuestionAnswer(Question question)
        {
            //TODO: will be implemented on demand
            return Task.CompletedTask;
        }
    }
}