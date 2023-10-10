using AutoMapper;
using LibraryAPI.Application.Dtos.Views.BarrowedBookViews;
using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BarrowEntites;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService
{
    public class BarrowedBookReadManager : IBarrowedBookReadService
    {
        private readonly IBarrowedBookReadRepository _barrowedBookReadRepository;
        private readonly IMapper _mapper;
        public BarrowedBookReadManager(IBarrowedBookReadRepository barrowedBookReadRepository, IMapper mapper)
        {
            _barrowedBookReadRepository = barrowedBookReadRepository;
            _mapper = mapper;
        }
        public async Task<List<ResponseAllBarrowedBooks>> GetAllBarrowedBooks()
        {
            string[] realtions = {BarrowedBookNavigations.User, BarrowedBookNavigations.Book, BarrowedBookNavigations.Authors,BarrowedBookNavigations.Category,BarrowedBookNavigations.Publisher };
            var res = await _barrowedBookReadRepository.GetQuery(includes: realtions)
                .Select(x => new ResponseAllBarrowedBooks
                {
                    AuthorName = x.Book.Authors.Select(a => a.Author.AuthorName).ToList(),
                    BookName = x.Book.BookName,
                    CategoryName = x.Book.Category.CategoryName,
                    FirstName= x.User.FirstName,
                    LastName= x.User.LastName,
                    IdentityNumber=x.User.IdentityNumber,
                    PublisherName=x.Book.Publisher.PublisherName,
                    UserName=x.User.UserName

                }).ToListAsync();

            if (res.Count == 0) throw new BusinessException("Barrowed Books Not found.");
            return res;
        }
    }
}
