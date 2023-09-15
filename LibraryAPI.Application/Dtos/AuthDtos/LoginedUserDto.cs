using LibraryAPI.Application.Interfaces;
using LibraryAPI.Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Dtos.AuthDtos
{
    public class LoginedUserDto : IDto
    {
        public AccessToken AccessToken { get; set; }
    }
}
