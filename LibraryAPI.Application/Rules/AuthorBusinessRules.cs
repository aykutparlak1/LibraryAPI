using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Rules
{
    public class AuthorBusinessRules
    {
        private readonly IAuthorReadRepository _authorReadRepository;

        public AuthorBusinessRules(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }
        public async Task AuthorShouldExists(int Id)
        {
            var res = await _authorReadRepository.GetAsync(x => x.Id == Id);
            if (res == null) throw new BusinessException("Author not found.");
        }
        public void AuthorShouldExistsWhenRequest(Author author)
        {
            if (author == null) throw new BusinessException("Author not found.");
        }

        public async Task AuthorAlreadyExits(Author author)
        {
            string fullName = author.AuthorFirstName.ToLower() + author.AuthorLastName.ToLower();
            var request = await _authorReadRepository.GetAsync(x => x.AuthorFirstName.ToLower() + x.AuthorLastName.ToLower() == fullName);
            if (request != null) throw new BusinessException("Author Already Exists");

        }
    }
}
