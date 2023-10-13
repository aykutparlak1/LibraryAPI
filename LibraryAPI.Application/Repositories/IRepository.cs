
using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Repositories
{
    public interface IRepository<T> where T : class, IEntity , new()
    {
        DbSet<T> Table { get; }
    }
}
