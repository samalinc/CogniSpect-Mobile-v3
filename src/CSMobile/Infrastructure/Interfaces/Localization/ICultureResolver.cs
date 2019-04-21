using System.Globalization;

namespace CSMobile.Infrastructure.Interfaces.Localization
{
    public interface ICultureResolver
    {
        CultureInfo GetCurrentCultureInfo();
    }
}