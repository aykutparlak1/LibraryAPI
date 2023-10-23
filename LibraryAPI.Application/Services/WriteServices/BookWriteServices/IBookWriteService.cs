using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.BookResources;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public interface IBookWriteService
    {
        Task<AddBookDto> AddBook(AddBookDto addBookDto);
        Task<UpdateBookDto> UpdateBook(UpdateBookDto updateBookDto);
        Task<bool> DeleteBook(int id);
    }
}
