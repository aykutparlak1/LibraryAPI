using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.AuthorService
{
    public interface IAuthorWriteService
    {
        Task CreateAuthorAsync(Author model);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);
    }
}
