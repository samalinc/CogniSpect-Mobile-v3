using System;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.Json
{
    /// <summary>
    /// Provides basic json conversation functionality
    /// </summary>
    public interface IJsonConverter
    {
        /// <summary>
        /// Deserializes corresponded string in json format to specified type
        /// </summary>
        /// <param name="rawString"><see cref="string"/> to be deserialized</param>
        /// <param name="type">Type of object</param>
        /// <returns>Object of corresponded type</returns>
        [CanBeNull]
        object Deserialize([CanBeNull] string rawString, Type type);

        /// <summary>
        /// Deserializes corresponded string in json format to specified type
        /// </summary>
        /// <param name="rawString"><see cref="string"/> to be deserialized</param>
        /// <typeparam name="TObject">Type of object</typeparam>
        /// <returns>Object of corresponded type</returns>
        [CanBeNull]
        TObject Deserialize<TObject>([CanBeNull] string rawString);

        /// <summary>
        /// Serializes object to json format object
        /// </summary>
        /// <param name="value"><see cref="object"/> to be serialized</param>
        /// <returns>Json representation of object</returns>
        [NotNull]
        string Serialize([CanBeNull] object value);
    }
}