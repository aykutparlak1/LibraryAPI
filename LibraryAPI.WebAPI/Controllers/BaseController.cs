using LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService;
using LibraryAPI.Application.Services.ReadServices.BookReadService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly IBookReadService _bookReadService;
    private readonly IBarrowedBookReadService _barrowedBookReadService;

    public BaseController(IBookReadService bookReadService, IBarrowedBookReadService barrowedBookReadService)
    {
        _barrowedBookReadService = barrowedBookReadService;
       _bookReadService = bookReadService;
    }
    [HttpGet("getallbook")]
    public async Task<IActionResult> GetAllBook()
    {
        var res = await _bookReadService.GetAll();
        return Ok(res);
    }
    [HttpGet("getallbookbyauthorname")]
    public async Task<IActionResult> GetAllBookByAuthorName(string authorName)
    {
        var res = await _bookReadService.GetByAuthor(authorName);
        return Ok(res);
    }
    [HttpGet("getallbarrowedbooks")]
    public async Task<IActionResult> GetAllBarrowedBooks()
    {
        var res = await _barrowedBookReadService.GetAllBarrowedBooks();
        return Ok(res);
    }
}
