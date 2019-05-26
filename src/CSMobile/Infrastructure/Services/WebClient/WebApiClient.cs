using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Interfaces.Exceptions;
using CSMobile.Infrastructure.Interfaces.Json;
using CSMobile.Infrastructure.Interfaces.WebClient;

namespace CSMobile.Infrastructure.Services.WebClient
{
    internal class WebApiClient : IWebApiClient
    {
        private readonly IJsonConverter _jsonConverter;

        public WebApiClient(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

//        private const string WebApiUrl = "http://10.0.2.2:8080/api";
        private const string WebApiUrl = "http://cognispect.herokuapp.com/api";

        public async Task<WebApiResponse<TData>> GetRequest<TData>(string endPoint,
            WebApiSecurityOptions securityOptions) where TData : class
        {
            return await Request<TData>(new WebApiRequestOptions
            {
                Method = HttpMethod.Get,
                Endpoint = endPoint,
                SecurityToken = securityOptions
            });
        }

        public async Task<WebApiResponse> Request(WebApiRequestOptions requestOptions)
        {
            HttpResponseMessage result = await Request(FormRequest(requestOptions), requestOptions.SecurityToken);
            return new WebApiResponse(IsSucceeded(result));
        }

        public async Task<WebApiResponse<TData>> Request<TData>(WebApiRequestOptions requestOptions) where TData : class
        {
            HttpResponseMessage result = await Request(FormRequest(requestOptions), requestOptions.SecurityToken);

            return new WebApiResponse<TData>(IsSucceeded(result), await GetResponseData<TData>(result));
        }

        private async Task<HttpResponseMessage> Request(HttpRequestMessage request,
            WebApiSecurityOptions securityOptions)
        {
            HttpResponseMessage result;

            try
            {
                using (var client = UpdateWithAuthenticationTokenIfNeeded(new HttpClient(), securityOptions))
                {
                    result = await client.SendAsync(request);
                }
            }
            catch (Exception e)
            {
                throw new HttpConnectionException(e);
            }

            return result;
        }

        private HttpClient UpdateWithAuthenticationTokenIfNeeded(
            HttpClient client,
            WebApiSecurityOptions securityOptions)
        {
            if (securityOptions == null)
            {
                return client;
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(securityOptions.Name, securityOptions.Value);
            
            return client;
        }

        private async Task<TData> GetResponseData<TData>(HttpResponseMessage result) where TData : class
        {
            if (!result.IsSuccessStatusCode)
            {
                return null;
            }

            // TODO: add support of other complex types (e.g. multipart, files and etc)
            string json = await result.Content.ReadAsStringAsync();

            return _jsonConverter.Deserialize<TData>(json);
        }

        private HttpRequestMessage FormRequest(WebApiRequestOptions requestOptions)
        {
            var message = new HttpRequestMessage
            {
                Method = requestOptions.Method,
                RequestUri = new Uri($"{WebApiUrl}/{requestOptions.Endpoint}")
            };
            SetContentIfNeeded(message, requestOptions);
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            message.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));

            return message;
        }

        private void SetContentIfNeeded(HttpRequestMessage message, WebApiRequestOptions requestOptions)
        {
            if (requestOptions.Method == HttpMethod.Get)
            {
                return;
            }

            // TODO: add support of other types of content
            message.Content = new StringContent(
                _jsonConverter.Serialize(requestOptions.Body),
                Encoding.UTF8,
                "application/json");
        }

        private bool IsSucceeded(HttpResponseMessage responseMessage)
        {
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new NotAuthorizedException();
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException();
                case HttpStatusCode.NotFound:
                    throw new NotFoundException();
            }

            return responseMessage.IsSuccessStatusCode;
        }
    }
}