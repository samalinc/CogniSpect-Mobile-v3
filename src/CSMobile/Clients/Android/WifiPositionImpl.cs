using Android.Content;
using Android.Net.Wifi;
using System.Linq;

public class WifiPositionImpl : IWifiPositionsServise()
{
    private Context context = null;
    private static WifiManager wifi;
    private static string wifiName = "";
    private static int MAX_POINTS = 4;
    private static int MIN_POINTS = 3;

    public WifiPositionImpl(Context ctx)
    {
        this.context = ctx;
    }

    public override bool IsPositionOk()
    {
        // Get a handle to the WifiPositionImpl
        wifi = (WifiManager) context.GetSystemService(Context.WifiService);
        var wifiNetworks = wifi.ScanResults;
        if (wifiNetworks.Count >= MIN_POINTS && wifiNetworks.Count <= MAX_POINTS)
        {
            return wifiNetworks.Where(wifinetwork => wifinetwork.VenueName.ToString().Equals(wifiName))
                .All(wifinetwork => IsSignalGood(wifinetwork.Level));
        }

        return false;
    }

    private bool IsSignalGood(int levelIndBm)
    {
        // @link https://stackoverflow.com/questions/13932724/getting-wifi-signal-strength-in-android
        return (levelIndBm <= 0 && levelIndBm >= -50) || (levelIndBm < -50 && levelIndBm >= -70);
    }
}