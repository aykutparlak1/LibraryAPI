using LibraryAPI.Application.Repositories.BookRepositories.BookAuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.BookAuthorRepository
{
    public class BookAuthorWriteRepository : WriteRepository<BookAuthor>, IBookAuthorWriteRepository
    {
        public BookAuthorWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
