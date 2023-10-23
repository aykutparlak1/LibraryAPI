using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Dtos.Views.AuthorViews;
using LibraryAPI.Dtos.Views.BookViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.BookReadService
{
    public class BookReadManager : IBookReadService
    {
        private readonly IBookReadRepository  _bookReadRepository;
        private readonly string[] relations = { BookNavigations.Authors, BookNavigations.Publisher, BookNavigations.Category };




        public BookReadManager(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        public async Task<List<ResponseBookDto>> GetAllBook()
        {
            var res = await _bookReadRepository.GetQuery(includes: relations)
                .Select(book => new ResponseBookDto
            {
                Id = book.Id,
                BookName = book.BookName,
                Authors = book.Authors.Select(author => new ResponseAuthorDto { AuthorName = author.Author.AuthorName }).ToList(),
                CategoryName = book.Category.CategoryName,
                Location = book.Location,
                NumberOfPages = book.NumberOfPages,
                PublisherName = book.Publisher.PublisherName
            }).ToListAsync();
            if(res == null || res.Count == 0) throw new BusinessException("Books Not Found.");
            return res;
        }

        public async Task<List<ResponseBookDto>> GetBooksByAuthorId(int authorId)
        {

            var res = await _bookReadRepository.GetQuery(filter: b => b.Authors.Any(a => a.Author.Id == authorId), includes: relations)
                .Select(book => new ResponseBookDto
                {
                    Id = book.Id,
                    BookName = book.BookName,
                    Authors = book.Authors.Select(author => new ResponseAuthorDto { AuthorName = author.Author.AuthorName }).ToList(),
                    CategoryName = book.Category.CategoryName,
                    Location = book.Location,
                    NumberOfPages = book.NumberOfPages,
                    PublisherName = book.Publisher.PublisherName
                })
                .ToListAsync();
            if(res==null || res.Count == 0) throw new BusinessException("Books Not Found.");
            return res;
        }

        public async Task<ResponseBookDto> GetBookById(int id)
        {
            
            var res = await _bookReadRepository.GetQuery(filter:x=>x.Id==id,includes: relations)
                .Select(book => new ResponseBookDto
                {
                    Id = book.Id,
                    BookName = book.BookName,
                    Authors = book.Authors.Select(author => new ResponseAuthorDto { AuthorName = author.Author.AuthorName }).ToList(),
                    CategoryName = book.Category.CategoryName,
                    Location = book.Location,
                    NumberOfPages = book.NumberOfPages,
                    PublisherName = book.Publisher.PublisherName
                })
                .SingleOrDefaultAsync();
            if(res == null) throw new BusinessException("Book Not Found.");
            return res;
        }

        public async Task<List<ResponseBookDto>> GetBooksByPublisherId(int publisherId)
        {
            var res = await _bookReadRepository.GetQuery(filter:x=>x.Publisher.Id== publisherId, includes: relations)
                .Select(book => new ResponseBookDto
                {
                    Id = book.Id,
                    BookName = book.BookName,
                    Authors = book.Authors.Select(author => new ResponseAuthorDto { AuthorName = author.Author.AuthorName }).ToList(),
                    CategoryName = book.Category.CategoryName,
                    Location = book.Location,
                    NumberOfPages = book.NumberOfPages,
                    PublisherName = book.Publisher.PublisherName
                })
                .ToListAsync();
            if(res == null || res.Count == 0) throw new BusinessException("Book Not Found.");
            return res;
        }
    }
}
