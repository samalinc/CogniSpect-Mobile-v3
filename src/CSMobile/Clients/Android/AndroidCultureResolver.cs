using System.Globalization;
using CSMobile.Infrastructure.Interfaces.Localization;
using Java.Util;

namespace CSMobile.Presentation.Droid
{
    internal class AndroidCultureResolver : ICultureResolver
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            Locale androidLocale = Locale.Default;
            string netLanguage = androidLocale.ToString().Replace("_", "-");
            return new CultureInfo(netLanguage);
        }
    }
}