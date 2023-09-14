using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccesToken(User user);
    }
}
