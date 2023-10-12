using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.CategoryResources;

namespace LibraryAPI.Application.Services.WriteServices.CategoryWriteServices
{
    public interface ICategoryWriteService
    {
        Task<Category> AddCategory(AddCategoryDto addCategoryDto);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Category category);
    }
}
