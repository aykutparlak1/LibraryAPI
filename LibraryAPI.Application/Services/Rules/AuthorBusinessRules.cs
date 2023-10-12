using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.Rules
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
            var res = await _authorReadRepository.IsExist(x => x.Id == Id);
            if (!res) throw new BusinessException("Author not found.");
        }


        public async Task AuthorAlreadyExits(string authorName)
        {
            StringHelper.ToLowerAndRemoveSpaces(authorName);
            bool isExists = await _authorReadRepository.IsExist(x => x.AuthorName.ToLower().Replace(" ", "") == authorName);
            if (!isExists) throw new BusinessException($"{authorName}: Already Exists");

        }
    }
}
