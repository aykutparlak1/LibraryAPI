using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.PublisherResources;

namespace LibraryAPI.Application.Services.WriteServices.PublisherWriteServices
{
    public interface IPublisherWriteService
    {
        Task<Publisher> AddPublisher(AddPublisherDto addPublisherDto);
        Task<UpdatePublisherDto> UpdatePublisher(UpdatePublisherDto updatePublisherDto);
        Task<bool> DeletePublisher(int id);

    }
}
