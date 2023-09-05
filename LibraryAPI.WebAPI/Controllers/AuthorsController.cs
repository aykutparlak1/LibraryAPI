using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly IMediator _mediator;
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddAuthors")]
        public async Task<IActionResult> Post(CreateAuthorCommandRequest createAuthorCommandRequest)
        {
            CreatedAuthorDto r = await _mediator.Send(createAuthorCommandRequest);
            return Ok(r);
        }
    }
}
