using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Repositories.Interfaces;
using FinalProject.Database.Repositories;

namespace FinalProject.Api.Controllers
{
    /*
     * 1. Remove not used usings after made changes
     * 2. [Authorize(Roles = "User")] - authorize all class with this and you will not need to use duplicates on each method
     * 4. [Authorize] is not enough because app should be RoleBased authentication
     * 5. PersonController should not be using personRepository, remove it from there
     * 6.        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePerson([FromForm] PersonDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _personService.CreatePersonAsync(userId, dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }
        in this method you returning Task<IActionResult>, but at the end of result you are returning OK() which is action result,
        but inside OK(result) there is object/objects if you want to return an object to be visible or presented in swagger,
        after calling method, Task<IActionResult> actually should be: Task<ActionResult<PersonDto>> in your case
    * 7.
     * 
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
        for this same applies as in 6. option.
        OPTIONAL: better approach would be in PersonDto add new variable as: public int Id {get;set;}
        and remove not really necessary int id
        OPTIONAL EXCEPTION CASE: if you want to change an id of Person then this approach is totally fine 
    * 8.       var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value); y
     * ou do not need to int.Parse as .Value gets integer already, but if you need to parse, better approach would be tryParse
     * 9. all methods should be wrapped in try catch block
     */
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
