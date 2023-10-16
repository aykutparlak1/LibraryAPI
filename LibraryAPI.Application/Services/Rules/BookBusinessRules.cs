using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.BookResources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Services.Rules
{
    public class BookBusinessRules
    {
        private readonly IBookReadRepository _bookReadRepository;

        public BookBusinessRules(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        public async Task<Book> IfBookAlreadyExistsReturnBookElseThrowExceptionWithRelations(int id)
        {
            string[] relations = { BookNavigations.Authors, BookNavigations.Category, BookNavigations.Publisher };
            Book isExists = await _bookReadRepository.GetQuery(filter: x => x.Id == id, includes: relations).SingleOrDefaultAsync();
            if (isExists == null) { throw new BusinessException("Book Not Found."); }
            return isExists;
        }
        public async Task<Book> IfBookAlreadyExistsReturnBookElseThrowException(int id)
        {
            Book isExists = await _bookReadRepository.GetQuery(filter: x => x.Id == id).SingleOrDefaultAsync();
            if (isExists == null) { throw new BusinessException("Book Not Found."); }
            return isExists;
        }
    }
}
