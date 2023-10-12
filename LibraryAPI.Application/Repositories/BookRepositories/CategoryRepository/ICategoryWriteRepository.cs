﻿using LibraryAPI.Domain.Entities.BookEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository
{
    public interface ICategoryWriteRepository :IWriteRepository<Category>
    {
    }
}