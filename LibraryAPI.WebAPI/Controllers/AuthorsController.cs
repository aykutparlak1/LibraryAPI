using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAuthorByIWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    {

        [HttpPost("AddAuthors")]
        public async Task<IActionResult> CreateAuthor([FromForm] CreateAuthorCommandRequest createAuthorCommandRequest)
        {
            CommandAuthorDto r = await Mediator.Send(createAuthorCommandRequest);
            return Ok(r);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var qry = new GetAllAuthorQueryRequest();

            return Ok(await Mediator.Send(qry));
        }

        [HttpGet("GetAuthorByIdWT")]
        public async Task<IActionResult> GetAuthorByIdWT(int  id)
        {

            var qry = await Mediator.Send(new GetAuthorByIdWTQueryRequest(id));
            return Ok(qry);
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
