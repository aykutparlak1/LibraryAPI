using LibraryAPI.Dtos.Views.BookViews;

namespace LibraryAPI.Application.Services.ReadServices.BookReadService
{
    public interface IBookReadService
    {
        Task<List<ResponseBookDto>> GetAll();
        Task<ResponseBookDto> GetById(int id);
        Task<ResponseBookDto> GetByBookName(string bookName);
        Task<List<ResponseBookDto>> GetByAuthor(string authorName);
        Task<List<ResponseBookDto>> GetByPublisher(string publisherName);
    }
}
