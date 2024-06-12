using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{

    //4. All methods should be wrapped in try catch blocks
     

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;


        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;

        }

        [HttpPost("Register")]
        [AllowAnonymous]
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

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.LoginAsync(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            var token = _jwtService.GenerateJwtToken(result.Data.UserName, result.Data.UserId, result.Data.Role);
            return Ok(new { Token = token });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await _userService.GetUserAsync(userId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{userId}")]

        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

    }
}

