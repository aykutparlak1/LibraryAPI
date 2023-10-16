using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.Rules
{
    public class BarrowBookBusinessRules
    {
        private readonly IBarrowedBookReadRepository _barrowedBookReadRepository;
        private readonly IBookReadRepository _bookReadRepository;
        public BarrowBookBusinessRules(IBarrowedBookReadRepository barrowedBookReadRepository,IBookReadRepository bookReadRepository)
        {
            _barrowedBookReadRepository = barrowedBookReadRepository;
            _bookReadRepository = bookReadRepository;
        }


        public async Task BookIsExists(int bookId)
        {
            var res = await _bookReadRepository.IsExist(x=>x.Id==bookId);
            if (!res) throw new BusinessException("Book Not Found.");
        }
        public async Task BarrowIsExists(int bookId)
        {
            var res = await _barrowedBookReadRepository.IsExist(x => x.Id == bookId);
            if (!res) throw new BusinessException("Barrow Not Found.");
        }
        public async Task UserIsExists(int UserId)
        {
            var res = await _barrowedBookReadRepository.Table.Include(u => u.User).AnyAsync(x=>x.User.Id==UserId);
            if (!res) throw new BusinessException("User Not Found.");
        }
        public async Task BookAlreadyBarrowed(int bookId)
        {
            var res = await _barrowedBookReadRepository.GetQuery(x=>x.BookId == bookId).LastOrDefaultAsync();
            if (!res.IsReturn) throw new BusinessException("Book Already Barrowed");
        }
        public async Task NotAllowedUntilBookAtBarrow(int bookId)
        {
            var res = await _barrowedBookReadRepository.GetQuery(x => x.BookId == bookId).LastOrDefaultAsync();
            if (!res.IsReturn) throw new BusinessException("Not allowed until book not return from barrow");
        }
        public void BarrowEndTimeCantBeEqualsOrLessThanBarrowStartDate(DateTime barrowStartDate, DateTime barrowEndDate)
        {
            int value = DateTime.Compare(barrowStartDate, barrowEndDate);
            if (value == 0) throw new BusinessException("End date cannot be Equals start date.");
            if (value == 1) throw new BusinessException("Start date cannot be later than end date.");
        }
    }
}
