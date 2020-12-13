using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RideShareRestApi.Attributes;
using RideShareRestApi.Entity.Dto;
using RideShareRestApi.Service.Interfaces;

namespace RideShareRestApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [SkipAuth]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(model);

                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [SkipAuth]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(model);

                if (result)
                    return CreatedAtAction(nameof(Register), null);
                else
                    return BadRequest("Something happend when creating a user!");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("me")]
        public CurrentUserDto Me() => _userService.CurrentUser;
    }
}
