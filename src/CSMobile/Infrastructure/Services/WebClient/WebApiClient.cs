using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Common;
using CSMobile.Infrastructure.Interfaces.Exceptions;
using CSMobile.Infrastructure.Interfaces.WebClient;
using Newtonsoft.Json;

namespace CSMobile.Infrastructure.Services.WebClient
{
    internal class WebApiClient : IWebApiClient
    {
//        private const string WebApiUrl = "http://10.0.2.2:8080/api";
        private const string WebApiUrl = "http://cognispect.herokuapp.com/api";
        
        public async Task<WebApiResponse<TData>> GetRequest<TData>(string endPoint, WebApiSecurityOptions securityOptions) where TData: class
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
            HttpResponseMessage result = await Request(FormRequest(requestOptions));
            return new WebApiResponse(IsSucceeded(result));
        }

        public async Task<WebApiResponse<TData>> Request<TData>(WebApiRequestOptions requestOptions) where TData: class
        {
            HttpResponseMessage result = await Request(FormRequest(requestOptions));
            
            return new WebApiResponse<TData>(IsSucceeded(result), await GetResponseData<TData>(result));
        }

        private async Task<HttpResponseMessage> Request(HttpRequestMessage request)
        {            
            HttpResponseMessage result;
            
            try
            {
                using (var client = new HttpClient())
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

        private void AddAuthenticationToken(HttpRequestMessage request, WebApiSecurityOptions securityOptions)
        {
            if (securityOptions == null)
            {
                return;
            }
            
            request.Headers.Add(securityOptions.Name, securityOptions.Value);
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
            AddAuthenticationToken(message, requestOptions.SecurityToken);

            return message;
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