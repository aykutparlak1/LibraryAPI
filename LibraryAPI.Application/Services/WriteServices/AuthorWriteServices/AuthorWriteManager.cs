using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteServices
{
    public class AuthorWriteManager : IAuthorWriteService
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;
        private readonly IMapper _mapper;
        public AuthorWriteManager(IMapper mapper, IAuthorWriteRepository authorWriteRepository, AuthorBusinessRules authorBusinessRules)
        {
            _mapper = mapper;
            _authorWriteRepository = authorWriteRepository;
            _authorBusinessRules = authorBusinessRules;
        }
        public async Task<Author> AddAuthor(CreateAuthorDto model)
        {
           model.AuthorName= model.AuthorName.UppercaseFirstLetterOfEachWordAndOtherLower();
           await _authorBusinessRules.AuthorAlreadyExits(model.AuthorName);
 
            Author mappedAuthor = _mapper.Map<Author>(model);
            Author addedAuthor = _authorWriteRepository.Add(mappedAuthor);
            await _authorWriteRepository.SaveAsync();
            return addedAuthor;
        }
        public async Task<bool> DeleteAuthor(Author author)
        {
            await _authorBusinessRules.AuthorShouldExists(author.Id);
            bool isRemoved = _authorWriteRepository.Remove(author);
            await _authorWriteRepository.SaveAsync();
            return isRemoved;
        }
        public async Task<Author> UpdateAuthor(Author author)
        {
            author.AuthorName = author.AuthorName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _authorBusinessRules.AuthorShouldExists(author.Id);
            await _authorBusinessRules.AuthorAlreadyExits(author.AuthorName);
            var updatedAuthor =  _authorWriteRepository.Update(author);
            await _authorWriteRepository.SaveAsync();
            return updatedAuthor;
        }
    }
}
