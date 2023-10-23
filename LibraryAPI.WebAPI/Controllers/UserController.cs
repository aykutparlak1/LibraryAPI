using LibraryAPI.Application.Services.ReadServices.UserReadService;
using LibraryAPI.Application.Services.WriteServices.UserWriteServices;
using LibraryAPI.Dtos.Resources.UserResorces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserWriteService _userWriteService;
        private readonly IUserReadService _userReadService;
        public UserController(IUserReadService userReadService, IUserWriteService userWriteService)
        {
            _userReadService = userReadService;
            _userWriteService = userWriteService;   
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(CreateUserDto createUserDto)
        {
            var res = await _userWriteService.AddUser(createUserDto);
            return Ok(res);

        }
        [HttpPost("deleteUser")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var res = await _userWriteService.DeleteUser(id);
            return Ok(res);
        }
        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateAuthor(UpdateUserDto updateUserDto)
        {
            var res = await _userWriteService.UpdateUser(updateUserDto);
            return Ok(res);
        }

        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var res = await _userReadService.GetAllUser();
            return Ok(res);
        }
        [HttpGet("getUserById")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var res = await _userReadService.GetUserById(id);
            return Ok(res);
        }
        [HttpGet("getUserByUserName")]
        public async Task<IActionResult> GetUserbyUserName(string userName)
        {
            var res = await _userReadService.GetUserByUserName(userName);
            return Ok(res);
        }
        [HttpGet("getUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var res = await _userReadService.GetUserByEmail(email);
            return Ok(res);
        }
        [HttpGet("getUserByIdentityNumber")]
        public async Task<IActionResult> GetUserByIdentityNumber(long identityNumber)
        {
            var res = await _userReadService.GetUserByIdentityNumber(identityNumber);
            return Ok(res);
        }
    }
}
