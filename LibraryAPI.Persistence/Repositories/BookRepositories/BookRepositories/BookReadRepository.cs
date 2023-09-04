﻿using LibraryAPI.Application.Repositories.BookRepositories.BookRepositories;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.BookRepositories
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        public BookReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
