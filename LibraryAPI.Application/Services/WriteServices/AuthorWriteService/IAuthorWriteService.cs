using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteService
{
    public interface IAuthorWriteService
    {
        Task<Author> CreateAuthor(CreateAuthorDto model);
        Task<Author> UpdateAuthor(Author author);
        Task<Author> RemoveAuthor(Author author);
    }
}
