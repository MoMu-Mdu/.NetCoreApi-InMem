using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi2.APIProvider;
using WebApi2.DTOs;
using WebApi2.Model;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IAPIProvider _apiProvider;
        private readonly IMapper _mapper;
        public PersonController(IAPIProvider apiProvider, IMapper mapper)
        {
            _apiProvider = apiProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var personData = _apiProvider.Get<List<Person>>("api/Person");
            var returnObjet = _mapper.Map<IEnumerable<PersonDto>>(personData);
            return Ok(returnObjet);
        }
    }
}
