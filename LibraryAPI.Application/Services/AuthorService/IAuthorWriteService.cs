using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.AuthorService
{
    public interface IAuthorWriteService
    {
        Task<Author> CreateAuthor(Author model, CancellationToken cancellationToken);
        Task<Author> UpdateAuthor(Author author ,CancellationToken cancellationToken);
        Task<Author> RemoveAuthor(Author author, CancellationToken cancellationToken);
        Task<List<Author>> RemoveAuthorRange(List<Author> authors,CancellationToken cancellationToken);
    }
}
