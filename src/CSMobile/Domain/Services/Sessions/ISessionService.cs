using System.Collections.Generic;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Sessions;
using CSMobile.Domain.Models.Tests;
using CSMobile.Domain.Services.Exceptions;
using JetBrains.Annotations;

namespace CSMobile.Domain.Services.Sessions
{
    public interface ISessionService
    {
        /// <summary>
        /// Returns collection of <see cref="SessionListItem"/> for current user
        /// </summary>
        /// <returns>Collection of <see cref="SessionListItem"/></returns>
        Task<IEnumerable<SessionListItem>> GetSessionListItems();

        /// <summary>
        /// Begins user test session
        /// </summary>
        /// <param name="listItem"><see cref="SessionListItem"/></param>
        /// <exception cref="InvalidStudentLocation">Will be thrown if current user has invalid location</exception>
        /// <returns><see cref="Test"/> for this test session</returns>
        [ItemNotNull]
        Task<Test> BeginSession([NotNull] SessionListItem listItem);
    }
}