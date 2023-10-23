using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.CategoryResources;
using LibraryAPI.Dtos.Views.CategoryViews;

namespace LibraryAPI.Application.Services.WriteServices.CategoryWriteServices
{
    public interface ICategoryWriteService
    {
        Task<ResponseCategoryIdAndNameDto> AddCategory(AddCategoryDto addCategoryDto);
        Task<ResponseCategoryIdAndNameDto> UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategory(int id);
    }
}
