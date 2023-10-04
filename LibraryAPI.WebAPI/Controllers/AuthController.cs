using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Features.AuthFeatures.Commands.LoginUser;
using LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{

    [AllowAnonymous]
    public sealed class AuthController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginedUserDto r = await Mediator.Send(loginUserCommandRequest);
            return Ok(r);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Login(RegisterUserCommandRequest registerUserCommandRequest)
        {
            RegisteredUserDto r = await Mediator.Send(registerUserCommandRequest);
            return Ok(r);
        }
    }
}
