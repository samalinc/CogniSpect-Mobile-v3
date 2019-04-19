using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Net.Wifi;
using CSMobile.Infrastructure.Security;

namespace CSMobile.Presentation.Droid
{
    public class AndroidWifiPositionsService : IWifiPositionsService
    {
        private readonly Context _context;
        private static WifiManager _wifi;
        private static int MAX_POINTS = 4;
        private static int MIN_POINTS = 3;

        public AndroidWifiPositionsService()
        {
            _context = Android.App.Application.Context;
        }

        public bool IsPositionOk(IEnumerable<string> wifis)
        {
            // Get a handle to the WifiPositionImpl
            _wifi = (WifiManager) _context.GetSystemService(Context.WifiService);
            IList<ScanResult> wifiNetworks = _wifi.ScanResults;
            
            if (wifiNetworks.Count >= MIN_POINTS && wifiNetworks.Count <= MAX_POINTS)
            {
                return wifiNetworks
                    .Where(wifinetwork => wifis.Contains(wifinetwork.VenueName.ToString()))
                    .All(wifinetwork => IsSignalGood(wifinetwork.Level));
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