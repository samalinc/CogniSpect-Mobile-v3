using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.Localization
{
    public interface ILocalizer
    {
        [NotNull] string this[[NotNull] string key] { get; }

        [NotNull] string GetLocalizedValue([NotNull] string key);
    }
}