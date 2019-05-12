using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Android.Content;
using Android.Net.Wifi;
using TimeoutException = CSMobile.Infrastructure.Interfaces.Exceptions.TimeoutException;

namespace CSMobile.Presentation.Droid.PlatformDependentServices.Wifi
{
    internal class AndroidWifiReceiver : BroadcastReceiver
    {
        private readonly WifiManager _wifi;
        private IList<ScanResult> _wifiNetworks;
        private readonly AutoResetEvent _receiverAre;
        private Timer _tmr;
        private const int TimeoutMillis = 10000;

        public AndroidWifiReceiver(WifiManager wifi)
        {
            _wifi = wifi;
            _wifiNetworks = new List<ScanResult>();
            _receiverAre = new AutoResetEvent(false);
        }

        public IEnumerable<ScanResult> Scan()
        {
            _tmr = new Timer(Timeout, null, TimeoutMillis, System.Threading.Timeout.Infinite);
            _wifi.StartScan();
            _receiverAre.WaitOne();
            return _wifiNetworks;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            _wifiNetworks = _wifi.ScanResults.ToArray();
            _receiverAre.Set();
        }

        private void Timeout(object sender)
        {
            throw new TimeoutException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tmr.Dispose();
                _wifi.Dispose();
                _receiverAre.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }
}