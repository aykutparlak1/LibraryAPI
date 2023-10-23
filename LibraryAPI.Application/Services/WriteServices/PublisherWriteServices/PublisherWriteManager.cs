﻿using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
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
            await _publisherBusinessRules.PublisheryAlreadyExits(addPublisherDto.PublisherName);
            
            Publisher mappedPublisher = _mapper.Map<Publisher>(addPublisherDto);
            var AddedPublisher =  _publisherWriteRepository.Add(mappedPublisher);
            await _publisherWriteRepository.SaveAsync();
            return AddedPublisher;
        }

        public async Task<bool> DeletePublisher(int id)
        {
           var result=  await _publisherBusinessRules.IfPublisherExistsReturnPublisherOrThrowException(id);
            bool isRemoved =_publisherWriteRepository.Remove(result);
            await _publisherWriteRepository.SaveAsync();
            return isRemoved;
        }

        public async Task<UpdatePublisherDto> UpdatePublisher(UpdatePublisherDto updatePublisherDto)
        {
            updatePublisherDto.PublisherName = updatePublisherDto.PublisherName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _publisherBusinessRules.IfPublisherNotExists(updatePublisherDto.Id);
            await _publisherBusinessRules.PublisheryAlreadyExits(updatePublisherDto.PublisherName);
            Publisher mappedPublisher = _mapper.Map<Publisher>(updatePublisherDto);
            var updatedPublisher = _publisherWriteRepository.Update(mappedPublisher);
            await _publisherWriteRepository.SaveAsync();
            UpdatePublisherDto mappedUpdatedPublisher = _mapper.Map<UpdatePublisherDto>(updatedPublisher);
            return mappedUpdatedPublisher;
        }
    }
}
