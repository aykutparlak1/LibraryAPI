using LibraryAPI.Domain.Entities.BarrowEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepository
{
    public interface IBarrowedBookWriteRepository :IWriteRepository<BarrowedBook>
    {
    }
}
