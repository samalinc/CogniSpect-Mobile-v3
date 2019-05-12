using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Wifi;

namespace CSMobile.Infrastructure.Security
{
    internal class WifiPositionsService : IWifiPositionsService
    {
        private readonly IWifiManager _wifiManager;

        public WifiPositionsService(IWifiManager wifiManager)
        {
            _wifiManager = wifiManager;
        }

        private const int _maxPoints = 4;
        private const int _minPoints = 3;

        public async Task<bool> IsPositionOk(IEnumerable<string> wifis)
        {
//            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
//            if (status != PermissionStatus.Granted)
//            {
////                if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
////                {
////                    await DisplayAlert("Need location", "Gunna need that location", "OK");
////                }
//
//                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
//                //Best practice to always check that the key exists
//                if(results.ContainsKey(Permission.Location))
//                    status = results[Permission.Location];
//            }
            IEnumerable<WifiNetwork> wifiNetworks = await _wifiManager.GetAvailableNetworks();
            var currentNetworks = wifiNetworks
                .Where(r => wifis.Contains(r.Ssid))
                .ToArray();

            if (currentNetworks.Length >= _minPoints && currentNetworks.Length <= _maxPoints)
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