using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Dtos.Resources.BarrowBookResources;

namespace LibraryAPI.Application.Services.WriteServices.BarrowBookServices
{
    public interface IBarrowBookWriteService
    {
        Task<BarrowBookDto> AddBarrowedBook(BarrowBookDto barrowBookDto);
        Task<BarrowBookDto> UpdateABarrow(BarrowBookDto barrowedBook);
        Task<bool> DeleteBarrowedBook(int id);
    }
}
