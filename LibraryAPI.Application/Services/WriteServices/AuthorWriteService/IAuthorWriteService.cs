using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteService
{
    public interface IAuthorWriteService
    {
        Task<Author> CreateAuthor(Author model);
        Task<Author> UpdateAuthor(Author author);
        Task<Author> RemoveAuthor(Author author);
    }
}
