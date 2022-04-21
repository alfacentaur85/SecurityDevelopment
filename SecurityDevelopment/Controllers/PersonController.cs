using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SecurityDevelopment.Abstractions;
using SecurityDevelopment.Models;
using SecurityDevelopment.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using SecurityDevelopment.Validators;


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
        PersonValidator _validator;

        public PersonController(IConfiguration configuration, ILogger<PersonController> logger, IRepositoryPerson repository, IMapper mapper)
        {
            _configuration = configuration;
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _validator = new PersonValidator();
        }

        private bool ValidatePerson(PersonDTO personDTO)
        {
            var result = _validator.Validate(personDTO);
            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                _logger.LogError(error.ErrorMessage);
            }
            return false;
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
            foreach (var element in personDTOList)
            {
                if (!ValidatePerson(element))
                {
                    return null;
                }
            }

            var models = _mapper.Map<IEnumerable<PersonDTO>, List<Person>>(personDTOList);
            return _repository.Create(models);        
        }

        [HttpPut]
        public JsonResult Update([FromBody] IReadOnlyList<PersonDTO> personDTOList)
        {
            foreach (var element in personDTOList)
            {
                if (!ValidatePerson(element))
                {
                    return null;
                }
            }

            var models = _mapper.Map<IEnumerable<PersonDTO>, List<Person>>(personDTOList);
            return _repository.Update(models);
        }
    }
}
