using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.CategoryResources;

namespace LibraryAPI.Application.Services.WriteServices.CategoryWriteServices
{
    public interface ICategoryWriteService
    {
        Task<Category> AddCategory(AddCategoryDto addCategoryDto);
        Task<UpdateCategoryDto> UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategory(int id);
    }
}
