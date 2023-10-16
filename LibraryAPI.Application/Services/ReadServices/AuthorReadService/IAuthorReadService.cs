using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Application.Services.ReadServices.AuthorReadService
{
    public interface IAuthorReadService
    {
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> GetAuthorByNameAsync(string name);
        Task<List<ResponseAuthorDto>> GetAllView();
        Task<List<Author>> GetAll();

    }
}
