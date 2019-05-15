using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Net.Wifi;
using CSMobile.Infrastructure.Interfaces.Wifi;
using JetBrains.Annotations;

namespace CSMobile.Presentation.Droid.PlatformDependentServices.Wifi
{
    [UsedImplicitly]
    internal class AndroidWifiManager : IWifiManager
    {
        private readonly Context _context;

        public AndroidWifiManager(Context context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<WifiNetwork>> GetAvailableNetworks()
        {
            var wifi = (WifiManager) _context.GetSystemService(Context.WifiService);
            IEnumerable<ScanResult> availableNetworks = null;
            using (var wifiReceiver = new AndroidWifiReceiver(wifi))
            {
                _context.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
                await Task.Run(() =>
                {
                    // Start a scan and register the Broadcast receiver to get the list of Wifi Networks
                    availableNetworks = wifiReceiver.Scan();
                });
                _context.UnregisterReceiver(wifiReceiver);
            }
            
            return availableNetworks.Select(s => new WifiNetwork
            {
                Ssid = s.Ssid,
                Level = s.Level
            }).ToArray();
        }
    }
}