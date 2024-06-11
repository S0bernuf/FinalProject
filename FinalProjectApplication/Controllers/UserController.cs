using System.Security.Claims;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{

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

