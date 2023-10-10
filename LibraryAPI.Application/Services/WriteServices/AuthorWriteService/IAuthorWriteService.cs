using LibraryAPI.Application.Dtos.Resources.AuthorResources;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteService
{
    public interface IAuthorWriteService
    {
        Task<Author> CreateAuthor(CreateAuthorDto model);
        Task<Author> UpdateAuthor(Author author);
        Task<Author> RemoveAuthor(Author author);
    }
}
