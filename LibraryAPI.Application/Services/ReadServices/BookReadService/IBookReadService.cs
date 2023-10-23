using LibraryAPI.Dtos.Views.BookViews;

namespace LibraryAPI.Application.Services.ReadServices.BookReadService
{
    public interface IBookReadService
    {
        Task<List<ResponseBookDto>> GetAllBook();
        Task<ResponseBookDto> GetBookById(int id);
        Task<List<ResponseBookDto>> GetBooksByAuthorId(int authorId);
        Task<List<ResponseBookDto>> GetBooksByPublisherId(int publisherId);
    }
}
