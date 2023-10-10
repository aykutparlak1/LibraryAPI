using LibraryAPI.Application.Dtos.Views.BarrowedBookViews;

namespace LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService
{
    public interface IBarrowedBookReadService
    {
        Task<List<ResponseAllBarrowedBooks>> GetAllBarrowedBooks();

    }
}
