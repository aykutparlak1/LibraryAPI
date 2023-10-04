using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.AuthorService
{
    public class AuthorWriteManager : IAuthorWriteService
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        public AuthorWriteManager(IAuthorWriteRepository authorWriteRepository)
        {
            _authorWriteRepository = authorWriteRepository;
        }
        public async Task<Author> CreateAuthor(Author model, CancellationToken cancellationToken)
        {
            Author crtdAuthor = await _authorWriteRepository.AddAsync(model,cancellationToken);
            await _authorWriteRepository.SaveAsync(cancellationToken);
            return crtdAuthor;
        }

        public async Task<Author> RemoveAuthor(Author author, CancellationToken cancellationToken)
        {
            await _authorWriteRepository.Remove(author);
            await _authorWriteRepository.SaveAsync(cancellationToken);
            return author;
        }

        public async Task<List<Author>> RemoveAuthorRange(List<Author> authors, CancellationToken cancellationToken)
        {
            await _authorWriteRepository.RemoveRange(authors);
            await _authorWriteRepository.SaveAsync(cancellationToken);
            return authors;
        }

        public async Task<Author> UpdateAuthor(Author author, CancellationToken cancellationToken)
        {
            await _authorWriteRepository.Update(author);
            await _authorWriteRepository.SaveAsync(cancellationToken);
            return author;
        }
    }
}
