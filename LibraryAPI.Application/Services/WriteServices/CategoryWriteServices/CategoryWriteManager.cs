﻿using AutoMapper;
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
            await _categoryBusinnesRules.CategoryAlreadyExits(addCategoryDto.CategoryName);
           
            Category mappedCategory = _mapper.Map<Category>(addCategoryDto);
            var addedCategory =  _categoryWriteRepository.Add(mappedCategory);
            await _categoryWriteRepository.SaveAsync();
            return addedCategory;
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            await _categoryBusinnesRules.IfCategoryNotExists(category.Id);
            bool isRemoved =_categoryWriteRepository.Remove(category);
            await _categoryWriteRepository.SaveAsync();
            return isRemoved;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            category.CategoryName = category.CategoryName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _categoryBusinnesRules.IfCategoryNotExists(category.Id);
            await _categoryBusinnesRules.CategoryAlreadyExits(category.CategoryName);
            var updatedCategory =_categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();
            return updatedCategory;
        }
    }
}
