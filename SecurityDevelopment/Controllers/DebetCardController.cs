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
    public class DebetCardController : ControllerBase
    {
        private IRepositoryDebetCard _repository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DebetCardController> _logger;
        private readonly IMapper _mapper;

        public DebetCardController(IConfiguration configuration, ILogger<DebetCardController> logger, IRepositoryDebetCard repository, IMapper mapper)
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
        public JsonResult Create([FromBody] IReadOnlyList<DebetCardDTO> cardsDTOList)
        {
            var models = _mapper.Map<IEnumerable<DebetCardDTO>, List<DebetCard>>(cardsDTOList);
            return _repository.Create(models);
        }

        [HttpPut]
        public JsonResult Update([FromBody] IReadOnlyList<DebetCardDTO> cardsDTOList)
        {
            var models = _mapper.Map<IEnumerable<DebetCardDTO>, List<DebetCard>>(cardsDTOList);
            return _repository.Update(models);
        }
    }
}
