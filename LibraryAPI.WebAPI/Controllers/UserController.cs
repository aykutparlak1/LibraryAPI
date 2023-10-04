using LibraryAPI.Application.Dtos.AuthDtos;
using LibraryAPI.Application.Features.AuthFeatures.Commands.LoginUser;
using LibraryAPI.Application.Features.UserFeatures.Queries.GetAllUserQuerry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [AllowAnonymous]
    public sealed class UserController : BaseController
    {
        [HttpGet("getAllUser")]

        public async Task<IActionResult> GetAll()
        {
            GetAllUserQuerryRequest getAllUserQuerryRequest = new();
            var r = await Mediator.Send(getAllUserQuerryRequest);
            return Ok(r);
        }
    }
}
