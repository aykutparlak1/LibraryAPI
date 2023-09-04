﻿using LibraryAPI.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Repositories.UserRepositories.UserRepositories
{
    public interface IUserWriteRepository : IWriteRepository<User>
    {
    }
}
