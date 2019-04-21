using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.WebClient
{
    public class WebApiSecurityOptions
    {
        public WebApiSecurityOptions([NotNull] string name, [NotNull] string value)
        {
            Name = name;
            Value = value;
        }

        [NotNull] public string Name { get; }

        [NotNull] public string Value { get; }
    }
}