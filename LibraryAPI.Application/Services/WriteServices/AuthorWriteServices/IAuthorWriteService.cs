using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;
using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteServices
{
    public interface IAuthorWriteService
    {
        Task<ResponseAuthorIdAndNameDto> AddAuthor(AddAuthorDto model);
        Task<ResponseAuthorIdAndNameDto> UpdateAuthor(UpdateAuthorDto updateAuthorDto);
        Task<bool> DeleteAuthor(int id);
    }
}
