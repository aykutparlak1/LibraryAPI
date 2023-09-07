using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAuthorByIWT;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            UpdateAuthorDto r = await Mediator.Send(updateAuthorDto);
            return Ok(r);
        }


        [HttpPost("RemoveAuthor")]
        public async Task<IActionResult> RemoveAuthor([FromForm] int id)
        {
            var qrrt = new DeleteAuthorCommandRequest(id);
             await Mediator.Send(qrrt);
            return Ok("Deleted");
        }
    }
}
