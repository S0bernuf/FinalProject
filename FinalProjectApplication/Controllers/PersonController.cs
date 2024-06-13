﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;


namespace FinalProject.Api.Controllers
{
    /*  Task<IActionResult>, but at the end of result you are returning OK() which is action result,
        but inside OK(result) there is object/objects if you want to return an object to be visible or presented in swagger,
        after calling method, Task<IActionResult> actually should be: Task<ActionResult<PersonDto>> in your case
    * 2.
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
    
     
     */


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


