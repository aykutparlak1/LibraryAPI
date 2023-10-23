using LibraryAPI.Dtos.Views.BarrowedBookViews;

namespace LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService
{
    public interface IBarrowedBookReadService
    {
        Task<List<ResponseAllBarrowedBooksDto>> GetAllBarrowedBooks();
        Task<ResponseAllBarrowedBooksDto> GetBarrowedBooksById(int id);
        Task<List<ResponseUsersBarrowedBooksDto>> GetUserBarowedBooks(int userId);
        Task<ResponseAllBarrowedBooksDto> GetBarroweBooksByIsReturn(bool isReturn);

    }
}
