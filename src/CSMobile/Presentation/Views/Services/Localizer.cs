using CSMobile.Infrastructure.Interfaces.Localization;
using CSMobile.Presentation.Views.Resources;
using JetBrains.Annotations;

namespace CSMobile.Presentation.Views.Services
{
    [UsedImplicitly]
    public class Localizer : ILocalizer
    {
        public string this[string key] => GetLocalizedValue(key);

        public string GetLocalizedValue(string key)
        {
            return AppResource.ResourceManager.GetString(key) ?? key;
        }
    }
}