using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Dtos.Views.AuthorViews;
using LibraryAPI.Dtos.Views.BarrowedBookViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService
{
    public class BarrowedBookReadManager : IBarrowedBookReadService
    {
        private readonly IBarrowedBookReadRepository _barrowedBookReadRepository;

        public BarrowedBookReadManager(IBarrowedBookReadRepository barrowedBookReadRepository)
        {
            _barrowedBookReadRepository = barrowedBookReadRepository;
        }

        public async Task<List<ResponseAllBarrowedBooks>> GetAllBarrowedBooks()
        {
            string[] realtions = {BarrowedBookNavigations.User, BarrowedBookNavigations.Book, BarrowedBookNavigations.Authors,BarrowedBookNavigations.Category,BarrowedBookNavigations.Publisher };
            var res = await _barrowedBookReadRepository.GetQuery(includes: realtions)
                .Select(barrowedBook=> new ResponseAllBarrowedBooks
                {
                    BookName = barrowedBook.Book.BookName,
                    PublisherName = barrowedBook.Book.Publisher.PublisherName,
                    Authors = barrowedBook.Book.Authors.Select(author => new ResponseAuthorDto { AuthorName = author.Author.AuthorName }).ToList(),
                    CategoryName = barrowedBook.Book.Category.CategoryName,
                    FirstName = barrowedBook.User.FirstName,
                    LastName = barrowedBook.User.LastName,
                    UserName = barrowedBook.User.UserName,
                    IdentityNumber = barrowedBook.User.IdentityNumber
                }).ToListAsync();
            if (res==null) throw new BusinessException("Barrowed Books Not found.");
            return res;
        }
    }
}
