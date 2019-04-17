using System.Collections.Generic;

namespace CSMobile.Infrastructure.Security
{
    public interface IWifiPositionsService
    {
        bool IsPositionOk(IEnumerable<string> wifis);
    } 
}
