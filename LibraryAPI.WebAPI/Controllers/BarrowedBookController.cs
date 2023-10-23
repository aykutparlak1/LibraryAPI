using LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService;
using LibraryAPI.Application.Services.WriteServices.BarrowBookServices;
using LibraryAPI.Dtos.Resources.BarrowBookResources;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarrowedBookController : ControllerBase
    {
        private readonly IBarrowBookWriteService _barrowBookWriteService;
        private readonly IBarrowedBookReadService _barrowedBookReadService;
        public BarrowedBookController(IBarrowBookWriteService barrowBookWriteService, IBarrowedBookReadService barrowedBookReadService)
        {
            _barrowBookWriteService = barrowBookWriteService;
            _barrowedBookReadService = barrowedBookReadService;
        }
        [HttpPost("addBarrowedBook")]
        public async Task<IActionResult> AddBarrowedBook(BarrowBookDto barrowBookDto)
        {
            var res = await _barrowBookWriteService.AddBarrowedBook(barrowBookDto);
            return Ok(res);

        }
        [HttpPost("deleteBarrowedBook")]
        public async Task<IActionResult> DeleteBarrowedBook(int id)
        {
            var res = await _barrowBookWriteService.DeleteBarrowedBook(id);
            return Ok(res);
        }
        [HttpPost("updateBarrowedBook")]
        public async Task<IActionResult> UpdateAuthor(BarrowBookDto barrowBookDto)
        {
            var res = await _barrowBookWriteService.UpdateABarrow(barrowBookDto);
            return Ok(res);
        }

        [HttpGet("getAllBarrowedBooks")]
        public async Task<IActionResult> GetAllBarrowedBooks()
        {
            var res = await _barrowedBookReadService.GetAllBarrowedBooks();
            return Ok(res);
        }
        [HttpGet("getBarrowedBooksById")]
        public async Task<IActionResult> GetBarrowedBooksById(int id)
        {
            var res = await _barrowedBookReadService.GetBarrowedBooksById(id);
            return Ok(res);
        }
        [HttpGet("getBarrowedBooksByIsReturn")]
        public async Task<IActionResult> GetBarrowedBooksByIsReturn(bool isReturn)
        {
            var res = await _barrowedBookReadService.GetBarroweBooksByIsReturn(isReturn);
            return Ok(res);
        }
        [HttpGet("getUserBarrowedBooks")]
        public async Task<IActionResult> GetUserBarrowedBooks(int userId)
        {
            var res = await _barrowedBookReadService.GetUserBarowedBooks(userId);
            return Ok(res);
        }
    }
}
