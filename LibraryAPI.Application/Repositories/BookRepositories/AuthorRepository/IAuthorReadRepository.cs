using LibraryAPI.Domain.Entities.BookEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository
{
    public interface IAuthorReadRepository : IReadRepository<Author>
    {
    }
}
