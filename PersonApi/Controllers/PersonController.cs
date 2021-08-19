using System;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersonApi.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repo;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonRepository repo, ILogger<PersonController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        
        // GET people
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            _logger.LogInformation("called the GET people endpoint");
            try
            {
                var people = await _repo.GetPeople();
                return Ok(people);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetPeople)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}