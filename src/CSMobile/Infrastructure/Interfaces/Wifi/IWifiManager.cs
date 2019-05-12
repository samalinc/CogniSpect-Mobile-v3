using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMobile.Infrastructure.Interfaces.Wifi
{
    public interface IWifiManager
    {
        Task<IEnumerable<WifiNetwork>> GetAvailableNetworks();
    }
}