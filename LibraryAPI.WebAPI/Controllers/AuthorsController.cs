using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthorsController : BaseController
    {

        [HttpPost("AddAuthors")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommandRequest createAuthorCommandRequest)
        {
            CommandAuthorDto r = await Mediator.Send(createAuthorCommandRequest);
            return Ok(r);
        }



        [HttpPost("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromForm] UpdateAuthorCommandRequest updateAuthorDto)
        {
            CommandAuthorDto r = await Mediator.Send(updateAuthorDto);
            return Ok(r);
        }

        [HttpPost("RemoveAuthor")]
        public async Task<IActionResult> RemoveAuthor(DeleteAuthorCommandRequest deleteAuthorCommandRequest)
        {
             await Mediator.Send(deleteAuthorCommandRequest);
            return Ok("Deleted");
        }
    }
}
