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
            addCategoryDto.CategoryName =addCategoryDto.CategoryName.UppercaseFirstLetterOfEachWordAndOtherLower();
            var checkedCategory = await _categoryBusinnesRules.CategoryAlreadyExitsReturnCategory(addCategoryDto.CategoryName);
            if (checkedCategory != null) { return checkedCategory; }
            Category mappedCategory = _mapper.Map<Category>(addCategoryDto);
            await _categoryWriteRepository.AddAsync(mappedCategory);
            return mappedCategory;
        }

        public async Task DeleteCategory(Category category)
        {
            await _categoryBusinnesRules.IfCategoryNotExists(category.Id);
            await _categoryWriteRepository.Remove(category);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            category.CategoryName = category.CategoryName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _categoryBusinnesRules.IfCategoryNotExists(category.Id);
            await _categoryBusinnesRules.CategoryAlreadyExits(category.CategoryName);
            Category updatedCategory = await _categoryWriteRepository.Update(category);
            return updatedCategory;
        }
    }
}
