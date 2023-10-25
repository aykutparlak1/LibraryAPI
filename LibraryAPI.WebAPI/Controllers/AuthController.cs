using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Dtos.Resources.UserResorces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var res = await _authService.Login(loginUserDto);
            return Ok(res);

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            var res = await _authService.Register(createUserDto);
            return Ok(res);

        }
    }
}
