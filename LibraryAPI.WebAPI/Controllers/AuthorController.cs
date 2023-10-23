using LibraryAPI.Application.Services.ReadServices.AuthorReadService;
using LibraryAPI.Application.Services.WriteServices.AuthorWriteServices;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorWriteService _authorWriteService;
        private readonly IAuthorReadService _authorReadService;
        public AuthorController(IAuthorWriteService authorWriteService, IAuthorReadService authorReadService)
        {
            _authorReadService = authorReadService;
            _authorWriteService = authorWriteService;
        }
        [HttpPost("addAuthor")]
        public async Task<IActionResult> AddAuthor(AddAuthorDto createAuthorDto)
        {
            var res = await _authorWriteService.AddAuthor(createAuthorDto);
            return Ok(res);
          
        }
        [HttpPost("deleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var res = await _authorWriteService.DeleteAuthor(id);
            return Ok(res);
        }
        [HttpPost("updateAuthor")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto author)
        {
            var res = await _authorWriteService.UpdateAuthor(author);
            return Ok(res);
        }

        [HttpGet("getAllAuthorView")]
        public async Task<IActionResult> GetAllAuthorView()
        {
            var res = await _authorReadService.GetAllView();
            return Ok(res);
        }

        [HttpGet("getAllAuthorWithId")]
        public async Task<IActionResult> GetAllAuthor()
        {
            var res = await _authorReadService.GetAll();
            return Ok(res);
        }

        [HttpGet("getAuthorById")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var res = await _authorReadService.GetAuthorByIdAsync(id);
            return Ok(res);
        }
        [HttpGet("getAuthorByName")]
        public async Task<IActionResult> GetAuthorByName(string name)
        {
            var res = await _authorReadService.GetAuthorByNameAsync(name);
            return Ok(res);
        }
    }
}
