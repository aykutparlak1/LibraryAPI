using AutoMapper;
using LibraryAPI.Application.Dtos.Views.BookViews;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepositories;
using LibraryAPI.Application.Services.Enums.NavigationEnums;
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.BookReadService
{
    public class BookReadManager : IBookReadService
    {
        private readonly IBookReadRepository  _bookReadRepository;

        public BookReadManager(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;

        }
        public async Task<List<ResponseBook>> GetAll()
        {
            string[] relations = { BookNavigations.Authors, BookNavigations.Publisher, BookNavigations.Category };
            var res = await _bookReadRepository.GetQuery(includes: relations).Select(b => new ResponseBook
            {
                PublisherName = b.Publisher.PublisherName,
                AuthorName = b.Authors.Select(a => a.Author.AuthorName).ToList(),
                BookName = b.BookName,
                CategoryName = b.Category.CategoryName,
                Location = b.Location,
                NumberOfPages =b.NumberOfPages
            }).ToListAsync();
            return res;
        }
    }
}
