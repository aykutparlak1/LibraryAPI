using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Dtos.Resources.BarrowBookResources;

namespace LibraryAPI.Application.Services.WriteServices.BarrowBookServices
{
    public interface IBarrowBookService
    {
        Task<BarrowedBook> AddBarrowedBook(BarrowBookDto barrowBookDto);
        Task<BarrowedBook> UpdateABarrow(BarrowBookDto barrowedBook);
        Task<bool> DeleteBarrowedBook(BarrowedBook barrowedBook);
    }
}
