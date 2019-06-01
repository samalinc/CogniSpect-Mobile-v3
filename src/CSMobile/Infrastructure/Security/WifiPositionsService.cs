using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Wifi;

namespace CSMobile.Infrastructure.Security
{
    internal class WifiPositionsService : IWifiPositionsService
    {
        private readonly IWifiManager _wifiManager;
        
        private const int MaxPoints = 4;
        private const int MinPoints = 3;

        public WifiPositionsService(IWifiManager wifiManager)
        {
            _wifiManager = wifiManager;
        }

        public async Task<bool> IsPositionOk(IEnumerable<string> wifis)
        {
            IEnumerable<WifiNetwork> wifiNetworks = await _wifiManager.GetAvailableNetworks();
            var currentNetworks = wifiNetworks
                .Where(r => wifis.Contains(r.Ssid))
                .ToArray();

            if (currentNetworks.Length >= MinPoints && currentNetworks.Length <= MaxPoints)
            {
                return currentNetworks.All(el => IsSignalGood(el.Level));
            }

            return false;
        }

        private bool IsSignalGood(int levelIndBm)
        {
            // @link https://stackoverflow.com/questions/13932724/getting-wifi-signal-strength-in-android
            return levelIndBm <= 0 && levelIndBm >= -50 || levelIndBm < -50 && levelIndBm >= -70;
        }
    }
}