using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.BookResources;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public interface IBookWriteService
    {
        Task<Book> AddBook(AddBookDto addBookDto);
        Task<Book> UpdateBook(UpdateBookDto updateBookDto);
        Task<Book> DeleteBook(Book book);
    }
}
