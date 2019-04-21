using System.Collections.Generic;
using System.Threading.Tasks;
using CSMobile.Domain.Models.Sessions;

namespace CSMobile.Domain.Services.Sessions
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionListItem>> GetSessionListItems();
    }
}