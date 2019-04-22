using System.Collections.Generic;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Models.Tests;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Sessions
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionListItem>> GetSessionListItems();

        [ItemNotNull]
        Task<Test> BeginSession([NotNull] SessionListItem listItem);
    }
}