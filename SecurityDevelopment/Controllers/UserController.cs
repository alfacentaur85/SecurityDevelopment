using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using SecurityDevelopment.Abstractions;
using SecurityDevelopment.Requests;
<<<<<<< HEAD
using SecurityDevelopmentAddUsers;
=======
>>>>>>> main

namespace SecurityDevelopment.Controllers
{
    [ApiController]
    [Authorize]
    [Route("")]
    public class UserController : ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;

        private readonly IUserRepository _repository;


        public UserController(IUserRepository repository, ILogger<UserController> logger)
        {
            _logger = logger;

            _repository = repository;

        }

<<<<<<< HEAD
         [HttpPost]
         public async Task<IActionResult> Add([FromBody] IReadOnlyList<UserRequest> request)
         {
             await _repository.AddAsync(request);

             _logger.LogInformation("Added User(s) to DB");

             return Ok();
         }

        [HttpPost("AddUsers")]
        public void AddUsers([FromBody] IReadOnlyList<UserRequest> request)
        {
            _repository.AddUsr(request);

            _logger.LogInformation("Added User(s) to DB");
=======
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IReadOnlyList<UserRequest> request)
        {
            await _repository.AddAsync(request);
                
            _logger.LogInformation("Added User(s) to DB");

            return Ok();
>>>>>>> main
        }

        [HttpGet("userbyid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            
            var response = await _repository.GetByIdAsync(id);

            _logger.LogInformation("Get User by Id from DB");

            return Ok(response);
        }

        [HttpGet("userbyname")]
        public async Task<IActionResult> GetByName([FromQuery] string name )
        {

            var response = await _repository.GetByNameAsync(name);

            _logger.LogInformation("Get User by name from DB");

            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetWithPagination([FromQuery] int skip, int take, string search)
        {

            var response = await _repository.GetWithPaginationAsync(skip, take, search);

            _logger.LogInformation("Get Users with pagination");

            return Ok(response);
        }

        [HttpPut("users")]
        public async Task<IActionResult> Update([FromBody] IReadOnlyList<UserRequest> request)
        {
            await _repository.UpdateAsync(request);

            _logger.LogInformation("Updated User(s) in DB");

            return Ok();
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _repository.DeleteAsync(id);

            _logger.LogInformation("Deleted User By Id");

            return Ok();
        }


    }
}
