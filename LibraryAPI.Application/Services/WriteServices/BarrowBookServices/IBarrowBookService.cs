using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Dtos.Resources.BarrowBookResources;

namespace LibraryAPI.Application.Services.WriteServices.BarrowBookServices
{
    public interface IBarrowBookService
    {
        Task AddBarrowedBook(BarrowBookDto barrowBookDto);
        Task UpdateABarrow(BarrowBookDto barrowedBook);
        Task DeleteBarrowedBook(BarrowedBook barrowedBook);
    }
}
