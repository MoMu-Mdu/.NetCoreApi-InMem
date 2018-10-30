using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace WebApi2.APIProvider
{
    public class RestAPIProvder : IAPIProvider
    {
        public HttpClient _client { get; private set; }

        public RestAPIProvder()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44389/");
        }

        public T Get<T>(string resource)
        {
            var response = _client.GetAsync(resource, HttpCompletionOption.ResponseHeadersRead);
            var resContent = response.Result.Content;
            var resString = resContent.ReadAsStringAsync().Result;
            var resData = JsonConvert.DeserializeObject<T>(resString);
            return resData;
        }
    }
}
