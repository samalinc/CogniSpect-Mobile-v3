using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CSMobile.Infrastructure.Services.WebClient
{
    internal class WebApiClient : IWebApiClient
    {
//        private const string WebApiUrl = "http://10.0.2.2:8080/api";
        private const string WebApiUrl = "http://cognispect.herokuapp.com/api";
        private const string TokenName = "Bearer token";

        private readonly IUserContextService _userContextService;

        public WebApiClient(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }

        public async Task<WebApiResponse> Request(WebApiRequestOptions requestOptions)
        {
            HttpResponseMessage result = await Request(FormRequest(requestOptions));
            return new WebApiResponse(result.IsSuccessStatusCode);
        }

        public async Task<WebApiResponse<TData>> Request<TData>(WebApiRequestOptions requestOptions) where TData: class
        {
            HttpResponseMessage result = await Request(FormRequest(requestOptions));
            return new WebApiResponse<TData>(result.IsSuccessStatusCode, await GetResponseData<TData>(result));
        }

        private async Task<HttpResponseMessage> Request(HttpRequestMessage request)
        {
            await AddAuthenticationToken(request);
            
            HttpResponseMessage result;
            using (var client = new HttpClient())
            {
                result = await client.SendAsync(request);
            }

            return result;
        }

        private async Task AddAuthenticationToken(HttpRequestMessage request)
        {
            if (!await _userContextService.IsAuthenticated())
            {
                return;
            }
            
            request.Headers.Add(TokenName, _userContextService.GetUserSessionData("Token") as string);
        }

        private async Task<TData> GetResponseData<TData>(HttpResponseMessage result) where TData: class
        {
            if (!result.IsSuccessStatusCode)
            {
                return null;
            }
            
            // TODO: add support of other complex types (e.g. multipart, files and etc)
            string json = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TData>(json);
        }

        private HttpRequestMessage FormRequest(WebApiRequestOptions requestOptions)
        {
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(requestOptions.Body),
                Encoding.UTF8,
                "application/json");
            
            var message = new HttpRequestMessage
            {
                Method = requestOptions.Method,
                RequestUri = new Uri($"{WebApiUrl}/{requestOptions.Endpoint}"),
                // TODO: add support of other types of content
                Content = content
            };
            message.Headers.Add("Accept", "application/json");

            return message;
        }
    }
}