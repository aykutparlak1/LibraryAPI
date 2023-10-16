using LibraryAPI.Application.Services.WriteServices.AuthorWriteServices;
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
        public AuthorController(IAuthorWriteService authorWriteService)
        {
            _authorWriteService = authorWriteService;
        }
        [HttpPost("addAuthor")]
        public async Task<IActionResult> AddAuthor(CreateAuthorDto createAuthorDto)
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
    }
}
