using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;


namespace FinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;

        }

        [HttpPost]

        public async Task<ActionResult<PersonDto>> CreatePerson([FromForm] PersonDto dto)
        {
            try
            {
                Int32.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);
                var result = await _personService.CreatePersonAsync(userId, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<PersonDto>> UpdatePerson(int id, [FromForm] PersonDto dto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var result = await _personService.UpdatePersonAsync(userId, id, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{personId}")]

        public async Task<ActionResult<PersonDto>> GetPersonById(int personId)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var result = await _personService.GetPersonByIdAsync(userId, personId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{personId}")]
        public async Task<ActionResult> DeletePerson(int personId)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                await _personService.DeletePersonAsync(userId, personId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


