using System;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.Json
{
    public interface IJsonConverter
    {
        [CanBeNull]
        object Deserialize([CanBeNull] string rawString, Type type);
    }
}