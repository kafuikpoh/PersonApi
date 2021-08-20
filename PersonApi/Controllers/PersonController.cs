using System;
using System.Collections;
using System.Collections.Generic;
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
            try
            {
                var people = await _repo.GetPeople();
                var peopleDto = _mapper.Map<IEnumerable<PersonDto>>(people);
                return Ok(peopleDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetPeople)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}