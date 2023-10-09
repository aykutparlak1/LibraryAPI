using LibraryAPI.Application.Dtos.Views.BookViews;

namespace LibraryAPI.Application.Services.ReadServices.BookReadService
{
    public interface IBookReadService
    {
        Task<List<ResponseBook>> GetAll();
    }
}
