using Gateway.DataModels;
using Gateway.DataTransfer;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
       
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Delete(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            await sendRequest(request);
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        public async Task<T> PostForm<T>(string uri, IFormFile file, T form)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            if (file != null && file.Length > 0)
            {
                byte[] data;
                using (var br = new BinaryReader(file.OpenReadStream()))
                    data = br.ReadBytes((int)file.OpenReadStream().Length);

                
                ByteArrayContent bytes = new ByteArrayContent(data);


                string jsonString = JsonSerializer.Serialize(form);
                MultipartFormDataContent multiContent = new MultipartFormDataContent();

                multiContent.Add(bytes, "file", file.FileName);
                multiContent.Add(new StringContent(jsonString), "product-details");

                request.Content = multiContent;

                return await sendRequest<T>(request);
            }
            else
                throw new BadHttpRequestException("Bad File", 500);
        }
        public async Task<T> Put<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {
            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<ErrorMessage>();
                throw new Exception(error.Message);
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task sendRequest(HttpRequestMessage request)
        {
            
            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<ErrorMessage>();
                throw new Exception(error.Message);
            }
        }
    }
}
