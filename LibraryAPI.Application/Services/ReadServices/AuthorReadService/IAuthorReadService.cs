using LibraryAPI.Application.Dtos.Views.AuthorViews;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.ReadServices.AuthorReadService
{
    public interface IAuthorReadService
    {
        Task<Author> GetByIdAsync(int id);
        Task<List<ResponseAuthorDto>> GetAll();

    }
}
