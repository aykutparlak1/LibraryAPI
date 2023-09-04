﻿using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepositories;
using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories.BarrowRepositories
{
    public class BarrowedBookWriteRepository : WriteRepository<BarrowedBook>, IBarrowedBookWriteRepository
    {
        public BarrowedBookWriteRepository(LibraryContext context) : base(context)
        {
        }
    }
}
