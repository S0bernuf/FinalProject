using System.Security.Claims;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;
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

            public UserController(IUserService userService, IJwtService jwtService)
            {
                _userService = userService;
                _jwtService = jwtService;
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

                var token = _jwtService.GenerateJwtToken(result.Data.UserName, result.Data.Id);
                return Ok(new { Token = token });
            }

            [HttpPut("update")]
            [Authorize]
            public async Task<IActionResult> UpdateUser([FromForm] PersonDto dto)
            {
            throw new NotImplementedException();
        }

            [HttpGet("{id}")]
            [Authorize]
            public async Task<IActionResult> GetUserById(int id)
            {
            throw new NotImplementedException();
        }

            [HttpDelete("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                var result = await _userService.DeleteUserAsync(id);
                if (!result.Success)
                    return BadRequest(result.Message);

                return Ok(result);
            }
        }
    }

