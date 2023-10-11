using LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService;
using LibraryAPI.Application.Services.ReadServices.BookReadService;
using LibraryAPI.Application.Services.ReadServices.CustomerReadService;
using LibraryAPI.Application.Services.ReadServices.EmployeeReadService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly IBookReadService _bookReadService;
    private readonly IBarrowedBookReadService _barrowedBookReadService;
    private readonly ICustomerReadService _customerReadService;
    private readonly IEmployeeReadService _employeeReadService;

    public BaseController(IBookReadService bookReadService, IBarrowedBookReadService barrowedBookReadService, IEmployeeReadService employeeReadService, ICustomerReadService customerReadService)
    {
      _employeeReadService = employeeReadService;
        _customerReadService = customerReadService;
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
    [HttpGet("getallcustomer")]
    public async Task<IActionResult> GetAllCustomer()
    {
        var res = await _customerReadService.GetAllCustomer();
        return Ok(res);
    }
    [HttpGet("getcustomerbyidentitynumber")]
    public async Task<IActionResult> GetCustomerByIdentityNumber(long identityNumber)
    {
        var res = await _customerReadService.GetCustomerByIdentityNumber(identityNumber);
        return Ok(res);

    }
        [HttpGet("getallemployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var res = await _employeeReadService.GetAllEmployee();
            return Ok(res);
        }
    }
