using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
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
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IPublisherReadRepository _publisherReadRepository;

        public BookBusinessRules(IBookReadRepository bookReadRepository,ICategoryReadRepository categoryReadRepository,IAuthorReadRepository authorReadRepository,
            IPublisherReadRepository publisherReadRepository)
        {
            _authorReadRepository = authorReadRepository;
            _publisherReadRepository = publisherReadRepository;
            _bookReadRepository = bookReadRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task AuthorPublisherCategoryShouldExists(List<AuthorIds> authorIds, int categoryId, int publisherId)
        {
            bool categoryIsExists = await _categoryReadRepository.IsExist(x => x.Id == categoryId);
            if (!categoryIsExists) throw new BusinessException("Category not found.");
            bool publisherIsExists = await _publisherReadRepository.IsExist(x => x.Id == publisherId);
            if (!publisherIsExists) throw new BusinessException("Publisher not found.");
            foreach (var item in authorIds)
            {
                bool authorShouldExists = await _authorReadRepository.IsExist(x => x.Id == item.AuthorId);
                if (!authorShouldExists) throw new BusinessException($"{item.AuthorId} item found.");
            }
        }
        public async Task BookShouldExists(int id)
        {
            bool isExists = await _bookReadRepository.IsExist( x => x.Id == id);
            if (!isExists) throw new BusinessException("Book not found.");
        }
        public async Task<Book> IfBookExistsReturnBookElseThrowException(int id)
        {
            Book isExists = await _bookReadRepository.GetQuery(filter: x => x.Id == id).SingleOrDefaultAsync();
            if (isExists == null) { throw new BusinessException("Book not found."); }
            return isExists;
        }
    }
}
