using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepositories;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.PublisherRepositories
{
    public class PublisherReadRepository : ReadRepository<Publisher>, IPublisherReadRepository
    {
        public PublisherReadRepository(LibraryContext context) : base(context)
        {
        }
    }
}
