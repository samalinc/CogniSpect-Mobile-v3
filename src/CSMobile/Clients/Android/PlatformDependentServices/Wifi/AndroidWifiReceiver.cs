using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Net.Wifi;
using TimeoutException = CSMobile.Infrastructure.Interfaces.Exceptions.TimeoutException;

namespace CSMobile.Presentation.Droid.PlatformDependentServices.Wifi
{
    internal class AndroidWifiReceiver : BroadcastReceiver
    {
        private readonly WifiManager _wifi;
        private readonly TaskCompletionSource<IEnumerable<ScanResult>> _completionSource;
        private readonly object _lockObject = new object();
        private Timer _timer;
        private const int TimeoutMillis = 10000;

        public AndroidWifiReceiver(WifiManager wifi)
        {
            _wifi = wifi;
            _completionSource = new TaskCompletionSource<IEnumerable<ScanResult>>();
        }

        public Task<IEnumerable<ScanResult>> Scan()
        {
            _timer = new Timer(Timeout, null, TimeoutMillis, System.Threading.Timeout.Infinite);
#pragma warning disable 618
            _wifi.StartScan();
#pragma warning restore 618

            return _completionSource.Task;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            _completionSource.TrySetResult(_wifi.ScanResults.ToArray());
        }

        private void Timeout(object sender)
        {
            if (_completionSource.TrySetException(new TimeoutException()))
            {
                return;
            }
            
            DisposeTimer();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeTimer();
                _wifi.Dispose();
            }

            base.Dispose(disposing);
        }

        private void DisposeTimer()
        {
            lock (_lockObject)
            {
                _timer?.Dispose();
                _timer = null;
            }
        }
    }
}