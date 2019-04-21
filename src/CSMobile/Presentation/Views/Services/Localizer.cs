using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Presentation.Views.Resources;

namespace CSMobile.Presentation.Views.Services
{
    public class Localizer : ILocalizer
    {
        public string this[string key] => GetLocalizedValue(key);

        public string GetLocalizedValue(string key)
        {
            return AppResource.ResourceManager.GetString(key) ?? key;
        }
    }
}