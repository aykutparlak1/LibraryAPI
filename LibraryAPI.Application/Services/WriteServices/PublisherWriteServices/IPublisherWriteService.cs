using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.PublisherResources;

namespace LibraryAPI.Application.Services.WriteServices.PublisherWriteServices
{
    public interface IPublisherWriteService
    {
        Task<Publisher> AddPublisher(AddPublisherDto addPublisherDto);
        Task<Publisher> UpdatePublisher(Publisher publisher);
        Task<Publisher> DeletePublisher(Publisher publisher);

    }
}
