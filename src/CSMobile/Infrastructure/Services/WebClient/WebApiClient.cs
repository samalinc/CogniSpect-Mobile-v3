using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSMobile.Infrastructure.Services.WebClient
{
    internal class WebApiClient : IWebApiClient
    {
        private const string WebApiUrl = "";

        public async Task<WebApiResponse> Request(WebApiRequestOptions requestOptions)
        {
            HttpResponseMessage result = await Request(FormRequest(requestOptions));
            return new WebApiResponse(result.IsSuccessStatusCode);
        }

        public async Task<WebApiResponse<TData>> Request<TData>(WebApiRequestOptions requestOptions)
        {
            HttpResponseMessage result = await Request(FormRequest(requestOptions));
            return new WebApiResponse<TData>(result.IsSuccessStatusCode, await GetResponseData<TData>(result));
        }

        private async Task<HttpResponseMessage> Request(HttpRequestMessage request)
        {
            HttpResponseMessage result;
            using (var client = new HttpClient())
            {
                result = await client.SendAsync(request);
            }

            return result;
        }

        private async Task<TData> GetResponseData<TData>(HttpResponseMessage result)
        {
            // TODO: add support of other complex types (e.g. multipart, files and etc)
            string json = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TData>(json);
        }

        private HttpRequestMessage FormRequest(WebApiRequestOptions requestOptions)
        {
            var message = new HttpRequestMessage
            {
                Method = requestOptions.Method,
                RequestUri = new Uri($"{WebApiUrl}/{requestOptions.Endpoint}"),
                // TODO: add support of other types of content
                Content = new StringContent(JsonConvert.SerializeObject(requestOptions.Body))
            };

            return message;
        }
    }
}