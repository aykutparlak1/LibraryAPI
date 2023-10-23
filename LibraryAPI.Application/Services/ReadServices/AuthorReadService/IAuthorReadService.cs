using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Application.Services.ReadServices.AuthorReadService
{
    public interface IAuthorReadService
    {
        Task<ResponseAuthorIdAndNameDto> GetAuthorByIdAsync(int id);
        Task<ResponseAuthorIdAndNameDto> GetAuthorByNameAsync(string name);
        Task<List<ResponseAuthorDto>> GetAllView();
        Task<List<ResponseAuthorIdAndNameDto>> GetAll();

    }
}
