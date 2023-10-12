using LibraryAPI.Dtos.Resources.BookResources;
using LibraryAPI.Dtos.Views.BookViews;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public interface IBookWriteService
    {
        Task<ResponseBookDto> AddBook(AddBookDto addBookDto);
    }
}
