using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi2.APIProvider;
using WebApi2.DTOs;
using WebApi2.Model;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private string _baseAddress;
        public PersonController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _baseAddress = "https://localhost:44389/api/Person";
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44389/");
            var result = Client.GetAsync("api/Person", HttpCompletionOption.ResponseHeadersRead);
            var resData = await result.Result.Content.ReadAsStringAsync();
            var personData = JsonConvert.DeserializeObject<List<Person>>(resData);
            var personToReturn = _mapper.Map<IEnumerable<PersonDto>>(personData);

            return Ok(personToReturn);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
