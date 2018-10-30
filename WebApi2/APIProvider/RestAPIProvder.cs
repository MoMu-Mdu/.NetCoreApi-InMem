using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi2.Model;

namespace WebApi2.APIProvider
{
    //public class RestAPIProvder
    //{
    //    private readonly IHttpClientFactory _httpClientFactory;
    //    private string _baseAddress;
    //    public RestAPIProvder(IHttpClientFactory clientFactory)
    //    {
    //        _httpClientFactory = clientFactory;
    //        _baseAddress = "https://localhost:44389/api/Person";
    //    }

    //    public void PrepareClient()
    //    {
    //        var client = _httpClientFactory.CreateClient();
    //        var result = client.GetStringAsync("/");
    //    }
    //}

    public class RestAPIProvder
    {
        public HttpClient Client { get; private set; }

        public RestAPIProvder()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44389/");
            var result = Client.GetAsync("api/Person", HttpCompletionOption.ResponseHeadersRead);
            var resData = result.Result.Content.ReadAsStringAsync();
            var personData = JsonConvert.DeserializeObject<Person>(resData.Result);
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            
        }
    }
}
