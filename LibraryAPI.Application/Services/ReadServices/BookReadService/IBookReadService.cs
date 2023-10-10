using LibraryAPI.Application.Dtos.Views.BookViews;

namespace LibraryAPI.Application.Services.ReadServices.BookReadService
{
    public interface IBookReadService
    {
        Task<List<ResponseBook>> GetAll();
        Task<ResponseBook> GetById(int id);
        Task<ResponseBook> GetByBookName(string bookName);
        Task<List<ResponseBook>> GetByAuthor(string authorName);
        Task<List<ResponseBook>> GetByPublisher(string publisherName);
    }
}
