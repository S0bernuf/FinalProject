using System.Security.Claims;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{
    
    /*
     * 1. using System.Security.Claims; - not used and should be removed
     * 2. Add [Authorize(Roles="Admin")] on top of the class, and open Register and Login methods with [AllowAnonymous]
     * 3. ex.: [HttpPost("register")] register and others should be capitalized
     * 4. All methods should be wrapped in try catch blocks
     * 5. PersonRepository shouldn't be used in UserController at all
     * 6. Update method is not necessary for you
     * 7. Do not overcomplicate:   return Ok(result.Data.Select(u => new { u.UserId, u.UserName })); just: return OK(result);
     * 8. TIP: GetById(int id) and Delete(int id) are basically identical, just one for delete another for retrieval;
     * 9.  public async Task<IActionResult> GetPersons()
        {
            var persons = await _personRepository.GetAllPersonsAsync();
            var result = persons.Select(p => new { p.PersonId, p.FirstName, p.LastName }).ToList();
            return Ok(result);
        }
        this method is using personRepository, you should be calling to userService.GerById(id);
     */

    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IPersonRepository _personRepository; 

        public UserController(IUserService userService, IJwtService jwtService, IPersonRepository personRepository)
        {
            _userService = userService;
            _jwtService = jwtService;
            _personRepository = personRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserSignupDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterAsync(dto);
            if (!result.Success) 
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.LoginAsync(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            var token = _jwtService.GenerateJwtToken(result.Data.UserName, result.Data.UserId);
            return Ok(new { Token = token });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromForm] PersonDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsersAsync();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Data.Select(u => new { u.UserId, u.UserName }));
        }

        [HttpGet("persons")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _personRepository.GetAllPersonsAsync();
            var result = persons.Select(p => new { p.PersonId, p.FirstName, p.LastName }).ToList();
            return Ok(result);
        }
    }
}

