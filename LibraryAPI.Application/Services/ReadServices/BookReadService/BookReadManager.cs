using AutoMapper;
using LibraryAPI.Application.Dtos.Views.BookViews;
using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.BookReadService
{
    public class BookReadManager : IBookReadService
    {
        private readonly IBookReadRepository  _bookReadRepository;
        private readonly string[] relations = { BookNavigations.Authors, BookNavigations.Publisher, BookNavigations.Category };
        private readonly IMapper _mapper;
        public BookReadManager(IBookReadRepository bookReadRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookReadRepository = bookReadRepository;

        }
        public async Task<List<ResponseBook>> GetAll()
        {

            var res = await _bookReadRepository.GetQuery(includes: relations).ToListAsync();
            if (res.Count == 0) throw new BusinessException("Books Not Found.");
            List<ResponseBook> responseBook = _mapper.Map<List<ResponseBook>>(res);
            return responseBook;
        }

        public async Task<List<ResponseBook>> GetByAuthor(string authorName)
        {

            var res = await _bookReadRepository.GetQuery(includes: relations).Select(b => new ResponseBook
            {
                PublisherName = b.Publisher.PublisherName,
                AuthorName = b.Authors.Select(a => a.Author.AuthorName).ToList(),
                BookName = b.BookName,
                CategoryName = b.Category.CategoryName,
                Location = b.Location,
                NumberOfPages = b.NumberOfPages
            }).Where(x=>x.AuthorName.Contains(authorName)).ToListAsync();
            if (res.Count == 0) throw new BusinessException("Books Not Found.");
            return res;
        }

        public async Task<ResponseBook> GetById(int id)
        {
            
            var res = await _bookReadRepository.GetQuery(filter:x=>x.Id==id,includes: relations).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Book Not Found.");
            ResponseBook responseBook = _mapper.Map<ResponseBook>(res);
            return responseBook;
        }

        public async Task<ResponseBook> GetByBookName(string bookName)
        {
            var res = await _bookReadRepository.GetQuery(filter: x => x.BookName==bookName, includes: relations).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Book Not Found.");
            ResponseBook responseBook = _mapper.Map<ResponseBook>(res);
            return responseBook;
        }

        public async Task<List<ResponseBook>> GetByPublisher(string publisherName)
        {
            var res = await _bookReadRepository.GetQuery(includes: relations).Select(b => new ResponseBook
            {
                PublisherName = b.Publisher.PublisherName,
                AuthorName = b.Authors.Select(a => a.Author.AuthorName).ToList(),
                BookName = b.BookName,
                CategoryName = b.Category.CategoryName,
                Location = b.Location,
                NumberOfPages = b.NumberOfPages
            }).Where(x=>x.PublisherName == publisherName).ToListAsync();
            if (res == null) throw new BusinessException("Book Not Found.");
            return res;
        }
    }
}
