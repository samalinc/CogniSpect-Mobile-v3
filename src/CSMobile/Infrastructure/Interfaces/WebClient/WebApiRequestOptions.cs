using System.Net.Http;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Interfaces.WebClient
{
    public class WebApiRequestOptions
    {
        public HttpMethod Method { get; set; }

        public string Endpoint { get; set; }

        [CanBeNull] public WebApiSecurityOptions SecurityToken { get; set; }

        public object Body { get; set; }
    }
}