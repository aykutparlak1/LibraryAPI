using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteServices
{
    public interface IAuthorWriteService
    {
        Task<Author> AddAuthor(CreateAuthorDto model);
        Task<Author> UpdateAuthor(Author author);
        Task DeleteAuthor(Author author);
    }
}
