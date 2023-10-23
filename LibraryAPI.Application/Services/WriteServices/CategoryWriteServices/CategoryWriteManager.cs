using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.CategoryResources;
using LibraryAPI.Dtos.Views.CategoryViews;

namespace LibraryAPI.Application.Services.WriteServices.CategoryWriteServices
{
    public class CategoryWriteManager : ICategoryWriteService
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly CategoryBusinessRules _categoryBusinnesRules;
        private readonly IMapper _mapper;
        public CategoryWriteManager(ICategoryWriteRepository categoryWriteRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper)
        {
            _categoryBusinnesRules = categoryBusinessRules;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }
        public async Task<ResponseCategoryIdAndNameDto> AddCategory(AddCategoryDto addCategoryDto)
        {
            addCategoryDto.CategoryName =addCategoryDto.CategoryName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _categoryBusinnesRules.CategoryAlreadyExits(addCategoryDto.CategoryName);
           
            Category mappedCategory = _mapper.Map<Category>(addCategoryDto);
            var addedCategory =  _categoryWriteRepository.Add(mappedCategory);
            await _categoryWriteRepository.SaveAsync();
            ResponseCategoryIdAndNameDto mappAddedCategory = _mapper.Map<ResponseCategoryIdAndNameDto>(addedCategory);
            return mappAddedCategory;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = await _categoryBusinnesRules.IfCategoryExistReturnCategoryOrThrowException(id);
            bool isRemoved =_categoryWriteRepository.Remove(result);
            await _categoryWriteRepository.SaveAsync();
            return isRemoved;
        }

        public async Task<ResponseCategoryIdAndNameDto> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            updateCategoryDto.CategoryName = updateCategoryDto.CategoryName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _categoryBusinnesRules.IfCategoryNotExists(updateCategoryDto.Id);
            await _categoryBusinnesRules.CategoryAlreadyExits(updateCategoryDto.CategoryName);
            Category mappedCategory = _mapper.Map<Category>(updateCategoryDto);
            var updatedCategory =_categoryWriteRepository.Update(mappedCategory);
            await _categoryWriteRepository.SaveAsync();
            ResponseCategoryIdAndNameDto mappedUpdatedCategory = _mapper.Map<ResponseCategoryIdAndNameDto>(updatedCategory);
            return mappedUpdatedCategory;
        }
    }
}
