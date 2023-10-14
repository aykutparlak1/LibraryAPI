using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Utilities.Helpers;
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
            addPublisherDto.PublisherName=addPublisherDto.PublisherName.UppercaseFirstLetterOfEachWordAndOtherLower();
            Publisher CheckedPublisher = await _publisherBusinessRules.PublisheryAlreadyExitsReturnPublisher(addPublisherDto.PublisherName);
            if (CheckedPublisher != null) { return CheckedPublisher; }
            Publisher mappedPublisher = _mapper.Map<Publisher>(addPublisherDto);
            var addedPublisher = await _publisherWriteRepository.AddAsync(mappedPublisher);
            return addedPublisher;
        }

        public async Task DeletePublisher(Publisher publisher)
        {
            await _publisherBusinessRules.IfPublisherNotExists(publisher.Id);
            await _publisherWriteRepository.Remove(publisher);
        }

        public async Task<Publisher> UpdatePublisher(Publisher publisher)
        {
            publisher.PublisherName = publisher.PublisherName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _publisherBusinessRules.IfPublisherNotExists(publisher.Id);
            await _publisherBusinessRules.PublisheryAlreadyExits(publisher.PublisherName);
            await _publisherWriteRepository.Update(publisher);
            return publisher;
        }
    }
}
