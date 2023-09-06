using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            CreatedAuthorDto r = await Mediator.Send(createAuthorCommandRequest);
            return Ok(r);
        }
        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var qry = new GetAllAuthorQueryRequest();
    
        //    return Ok(await Mediator.Send(qry));
        //}
    }
}
