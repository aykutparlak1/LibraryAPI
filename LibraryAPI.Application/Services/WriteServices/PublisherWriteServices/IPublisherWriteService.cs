using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.PublisherResources;
using LibraryAPI.Dtos.Views.PublisherViews;

namespace LibraryAPI.Application.Services.WriteServices.PublisherWriteServices
{
    public interface IPublisherWriteService
    {
        Task<ResponsePublisherIdAndNameDto> AddPublisher(AddPublisherDto addPublisherDto);
        Task<ResponsePublisherIdAndNameDto> UpdatePublisher(UpdatePublisherDto updatePublisherDto);
        Task<bool> DeletePublisher(int id);

    }
}
