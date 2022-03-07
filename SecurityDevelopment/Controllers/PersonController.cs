using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SecurityDevelopment.Abstractions;
using SecurityDevelopment.Models;
using SecurityDevelopment.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace SecurityDevelopment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private IRepositoryPerson _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PersonController> _logger;
        private readonly IMapper _mapper;

        public PersonController(IConfiguration configuration, ILogger<PersonController> logger, IRepositoryPerson repository, IMapper mapper)
        {
            _configuration = configuration;
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public JsonResult GetAll()
        {   
            return _repository.GetAll();
        }

        [HttpGet("GetByAnyString")]
        public JsonResult GetByAnyString([FromQuery] string anyString)
        {
            return _repository.GetByAnyStringValue(anyString);
        }

        [HttpGet("GetById")]
        public JsonResult GetByAnyString([FromQuery] int id)
        {
            return _repository.GetById(id);
        }

        [HttpDelete]
        public JsonResult Delete([FromQuery] int Id)
        {
            return _repository.DeleteById(Id);
        }

        [HttpPost]
        public JsonResult Create([FromBody] IReadOnlyList<PersonDTO> personDTOList)
        {
            var models = _mapper.Map<IEnumerable<PersonDTO>, List<Person>>(personDTOList);
            return _repository.Create(models);        
        }

        [HttpPut]
        public JsonResult Update([FromBody] IReadOnlyList<PersonDTO> personDTOList)
        {
            var models = _mapper.Map<IEnumerable<PersonDTO>, List<Person>>(personDTOList);
            return _repository.Update(models);
        }
    }
}
