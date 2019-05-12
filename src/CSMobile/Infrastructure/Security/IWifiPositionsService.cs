using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Security
{
    public interface IWifiPositionsService
    {
        Task<bool> IsPositionOk(IEnumerable<string> wifis);
    } 
}
