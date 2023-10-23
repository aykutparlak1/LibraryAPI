using LibraryAPI.Application.Services.ReadServices.BookReadService;
using LibraryAPI.Application.Services.WriteServices.BookWriteServices;
using LibraryAPI.Dtos.Resources.BookResources;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookReadService _bookReadService;
        private readonly IBookWriteService _bookWriteService;
        public BookController(IBookReadService bookReadService, IBookWriteService bookWriteService)
        {
            _bookReadService = bookReadService;
            _bookWriteService = bookWriteService;
        }
        [HttpPost("addBook")]
        public async Task<IActionResult> AddAuthor(AddBookDto addBookDto)
        {
            var res = await _bookWriteService.AddBook(addBookDto);
            return Ok(res);

        }
        [HttpPost("updateBook")]
        public async Task<IActionResult> UpdateBook(UpdateBookDto updateBookDto)
        {
            var res = await _bookWriteService.UpdateBook(updateBookDto);
            return Ok(res);
        }
        [HttpPost("deleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var res = await _bookWriteService.DeleteBook(id);
            return Ok(res);
        }
        [HttpGet("getAllBook")]
        public async Task<IActionResult> GetAllBook()
        {
            var res = await _bookReadService.GetAllBook();
            return Ok(res);
        }
        [HttpGet("getBooksByAuthorId")]
        public async Task<IActionResult> GetBooksByAuthorId(int authorId)
        {
            var res = await _bookReadService.GetBooksByAuthorId(authorId);
            return Ok(res);
        }
        [HttpGet("getBooksByPublisherId")]
        public async Task<IActionResult> GetBooksByPublisherId(int publisherId)
        {
            var res = await _bookReadService.GetBooksByPublisherId(publisherId);
            return Ok(res);
        }
        [HttpGet("getBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var res = await _bookReadService.GetBookById(id);
            return Ok(res);
        }
    }
}
