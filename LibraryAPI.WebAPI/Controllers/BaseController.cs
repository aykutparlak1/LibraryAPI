using LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService;
using LibraryAPI.Application.Services.ReadServices.BookReadService;
using LibraryAPI.Application.Services.WriteServices.AuthorWriteServices;
using LibraryAPI.Application.Services.WriteServices.BookWriteServices;
using LibraryAPI.Dtos.Resources.AuthorResources;
using LibraryAPI.Dtos.Resources.BookResources;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly IBookReadService _bookReadService;
    private readonly IBarrowedBookReadService _barrowedBookReadService;
    private readonly IBookWriteService _bookWriteService;
    private readonly IAuthorWriteService _authorWriteService;


    public BaseController(IBookReadService bookReadService, IBarrowedBookReadService barrowedBookReadService, IBookWriteService bookWriteService,IAuthorWriteService authorWriteService)
    {
        _authorWriteService = authorWriteService;
        _bookWriteService = bookWriteService;   
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
    [HttpPost("addBook")]
    public async Task<IActionResult> AddBook(AddBookDto addBookDto)
    {
            await _bookWriteService.AddBook(addBookDto); 
            return Ok("Kitap EKlendi");
    }
    [HttpPost("addAuthor")]
    public async Task<IActionResult> addAuthor(CreateAuthorDto createAuthorDto)
    {
        await _authorWriteService.AddAuthor(createAuthorDto);
        return Ok("Kitap EKlendi");
    }

}
