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
    }
}