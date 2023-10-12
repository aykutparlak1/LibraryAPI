using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.CategoryResources;

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
        public async Task<Category> AddCategory(AddCategoryDto addCategoryDto)
        {
            await _categoryBusinnesRules.IfCategoryAlreadyExists(addCategoryDto.CategoryName);
            addCategoryDto.CategoryName = StringHelper.UppercaseFirstLetterOfEachWordAndOtherLower(addCategoryDto.CategoryName);
            Category mappedCategory = _mapper.Map<Category>(addCategoryDto);
            await _categoryWriteRepository.AddAsync(mappedCategory);
            return mappedCategory;
        }

        public async Task DeleteCategory(Category category)
        {
            await _categoryBusinnesRules.IsCategoryExist(category);
            await _categoryWriteRepository.Remove(category);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            await _categoryBusinnesRules.IsCategoryExist(category);
            await _categoryBusinnesRules.IfCategoryAlreadyExists(category.CategoryName);
            Category updatedCategory = await _categoryWriteRepository.Update(category);
            return updatedCategory;
        }
    }
}
