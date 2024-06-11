using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Repositories.Interfaces;
using FinalProject.Database.Repositories;

namespace FinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonService personService, IPersonRepository personRepository)
        {
            _personService = personService;
            _personRepository = personRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePerson([FromForm] PersonDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _personService.CreatePersonAsync(userId, dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePerson(int id, [FromForm] PersonDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _personService.UpdatePersonAsync(userId, id, dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{personId}")]
        [Authorize]
        public async Task<IActionResult> GetPersonById(int personId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _personService.GetPersonByIdAsync(userId, personId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }


    }
}
