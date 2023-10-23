using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;
using LibraryAPI.Dtos.Views.AuthorViews;

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
        public async Task<ResponseAuthorIdAndNameDto> AddAuthor(AddAuthorDto model)
        {
           model.AuthorName= model.AuthorName.UppercaseFirstLetterOfEachWordAndOtherLower();
           await _authorBusinessRules.AuthorAlreadyExits(model.AuthorName);
 
            Author mappedAuthor = _mapper.Map<Author>(model);
            Author addedAuthor = _authorWriteRepository.Add(mappedAuthor);
            await _authorWriteRepository.SaveAsync();
            ResponseAuthorIdAndNameDto mappedAddedAuthor = _mapper.Map<ResponseAuthorIdAndNameDto>(addedAuthor);
            return mappedAddedAuthor;
        }
        public async Task<bool> DeleteAuthor(int id)
        {
           var result =  await _authorBusinessRules.IfAuthorExistReturnAuthor(id);
            bool isRemoved = _authorWriteRepository.Remove(result);
            await _authorWriteRepository.SaveAsync();
            return isRemoved;
        }
        public async Task<ResponseAuthorIdAndNameDto> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            updateAuthorDto.AuthorName = updateAuthorDto.AuthorName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _authorBusinessRules.AuthorShouldExists(updateAuthorDto.Id);
            await _authorBusinessRules.AuthorAlreadyExits(updateAuthorDto.AuthorName);
            Author mappedAuthor = _mapper.Map<Author>(updateAuthorDto);
            var updatedAuthor =  _authorWriteRepository.Update(mappedAuthor);
            
            await _authorWriteRepository.SaveAsync();
            
            ResponseAuthorIdAndNameDto mappedUpdatedAuthor = _mapper.Map<ResponseAuthorIdAndNameDto>(updatedAuthor);
            return mappedUpdatedAuthor;
        }
    }
}
