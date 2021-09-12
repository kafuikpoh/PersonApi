using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects;
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
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository repo, ILogger<PersonController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }
        
        // GET people
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            _logger.LogInformation("called the GET people endpoint");
            
            var people = await _repo.GetPeople();
            var peopleDto = _mapper.Map<IEnumerable<PersonDto>>(people);
            
            _logger.LogInformation($"Returning {peopleDto.Count()} people objects", peopleDto);
            return Ok(peopleDto);
            
        }

        [HttpGet("{id}", Name = "PersonById")]
        public async Task<IActionResult> GetPerson(int id)
        {
            _logger.LogInformation("called the GET person by id endpoint");

            var person = await _repo.GetPerson(id);
            if (person == null)
                return NotFound();

            _logger.LogInformation("Returning a person object");
            
            return Ok(person);
        }
        
        //create people
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody]PersonForCreationDto person)
        {
            if (person == null)
            {
                _logger.LogError("PersonForCreationDto object sent form client is null");
                return BadRequest("PersonForCreationDto object is null");
            }

            var createdPerson = await _repo.CreatePerson(person);

            if (createdPerson == null)
            {
                _logger.LogError("Person Object could not be created");
                return StatusCode(500);
            }

            var personDto = _mapper.Map<PersonDto>(createdPerson);

            return CreatedAtRoute("PersonById", new { id = personDto.Person_Id }, personDto);
        }
    }
}