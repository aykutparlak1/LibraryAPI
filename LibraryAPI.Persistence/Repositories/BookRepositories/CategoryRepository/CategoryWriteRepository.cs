using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
