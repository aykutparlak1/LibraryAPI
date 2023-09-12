using LibraryAPI.Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Services.UserService
{
    public interface IUserService
    {
        Task<CreatedUserDto> CreateUserAsync();
    }
}
