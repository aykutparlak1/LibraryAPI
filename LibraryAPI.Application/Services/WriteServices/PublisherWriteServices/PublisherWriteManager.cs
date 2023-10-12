using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.PublisherResources;

namespace LibraryAPI.Application.Services.WriteServices.PublisherWriteServices
{
    public class PublisherWriteManager : IPublisherWriteService
    {

        private readonly IPublisherWriteRepository _publisherWriteRepository;
        private readonly PublisherBusinessRules _publisherBusinessRules;
        private readonly IMapper _mapper;
        
        public PublisherWriteManager(IPublisherWriteRepository publisherWriteRepository, PublisherBusinessRules publisherBusinessRules,IMapper mapper)
        {
            _publisherWriteRepository = publisherWriteRepository;
            _publisherBusinessRules = publisherBusinessRules;
            _mapper = mapper;
        }
        public async Task<Publisher> AddPublisher(AddPublisherDto addPublisherDto)
        {
            //addPublisherDto.PublisherName= StringHelper.UppercaseFirstLetterOfEachWordAndOtherLower(addPublisherDto.PublisherName);
            await _publisherBusinessRules.PublisherNameIsExists(addPublisherDto.PublisherName);
            Publisher mappedPublisher = _mapper.Map<Publisher>(addPublisherDto);
            var addedPublisher = await _publisherWriteRepository.AddAsync(mappedPublisher);
            return addedPublisher;
        }

        public async Task DeletePublisher(Publisher publisher)
        {
            await _publisherBusinessRules.PublisherIsNotExists(publisher.Id);
            await _publisherWriteRepository.Remove(publisher);
        }

        public async Task<Publisher> UpdatePublisher(Publisher publisher)
        {
            await _publisherBusinessRules.PublisherIsNotExists(publisher.Id);
            await _publisherBusinessRules.PublisherNameIsExists(publisher.PublisherName);
            await _publisherWriteRepository.Update(publisher);
            return publisher;
        }
    }
}
