using LibraryAPI.Application.Services.ReadServices.BookReadService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly IBookReadService _bookReadService;
    public BaseController(IBookReadService bookReadService)
    {
       _bookReadService = bookReadService;
    }
    [HttpGet("getallbook")]
    public async Task<IActionResult> GetAllBook()
    {
        var res = await _bookReadService.GetAll();
        return Ok(res);
    }
}
