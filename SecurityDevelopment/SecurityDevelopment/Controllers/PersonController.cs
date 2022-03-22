using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SecurityDevelopment.Abstractions;

namespace SecurityDevelopment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IRepositoryPerson _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IConfiguration configuration, ILogger<PersonController> logger, IRepositoryPerson repository)
        {
            _configuration = configuration;
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("all")]
        public JsonResult GetAll()
        {   
            return _repository.GetAll();
        }
    }
}
