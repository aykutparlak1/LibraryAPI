using LibraryAPI.Dtos.Resources.BookResources;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public interface IBookWriteService
    {
        Task AddBook(AddBookDto addBookDto);
    }
}
