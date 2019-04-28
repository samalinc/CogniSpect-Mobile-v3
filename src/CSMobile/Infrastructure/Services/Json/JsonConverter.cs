using System;
using CSMobile.Infrastructure.Interfaces.Json;
using Newtonsoft.Json;

namespace CSMobile.Infrastructure.Services.Json
{
    internal class JsonConverter : IJsonConverter
    {
        public object Deserialize(string rawString, Type type)
        {
            return JsonConvert.DeserializeObject(rawString, type);
        }

        public TObject Deserialize<TObject>(string rawString)
        {
            return JsonConvert.DeserializeObject<TObject>(rawString);
        }

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}