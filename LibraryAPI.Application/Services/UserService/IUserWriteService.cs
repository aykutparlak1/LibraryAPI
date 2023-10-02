using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Services.UserService
{
    public interface IUserWriteService
    {
        User CreateUser(CreateUserDto model);
    }
}
