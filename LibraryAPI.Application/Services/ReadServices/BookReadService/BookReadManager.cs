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
        public async Task<List<ResponseBookDto>> GetAll()
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

        public async Task<List<ResponseBookDto>> GetByAuthor(string authorName)
        {

            var res = await _bookReadRepository.GetQuery(filter: b => b.Authors.Any(a => a.Author.AuthorName == authorName), includes: relations)
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

        public async Task<ResponseBookDto> GetById(int id)
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

        public async Task<ResponseBookDto> GetByBookName(string bookName)
        {
            var res = await _bookReadRepository.GetQuery(filter: x => x.BookName==bookName, includes: relations)
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

        public async Task<List<ResponseBookDto>> GetByPublisher(string publisherName)
        {
            var res = await _bookReadRepository.GetQuery(filter:x=>x.Publisher.PublisherName==publisherName,includes: relations)
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
