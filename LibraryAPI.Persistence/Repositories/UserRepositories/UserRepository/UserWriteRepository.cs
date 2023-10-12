using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.UserRepositories.UserRepository
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
