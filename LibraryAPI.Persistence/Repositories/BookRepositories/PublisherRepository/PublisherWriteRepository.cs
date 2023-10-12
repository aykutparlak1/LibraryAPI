using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.BookRepositories.PublisherRepository
{
    public class PublisherWriteRepository : WriteRepository<Publisher>, IPublisherWriteRepository
    {
        public PublisherWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
