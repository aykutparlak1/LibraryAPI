using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Helpers;

namespace LibraryAPI.Application.Services.Rules
{
    public class PublisherBusinessRules
    {
        private readonly IPublisherReadRepository _publisherReadRepository;
        public PublisherBusinessRules(IPublisherReadRepository publisherReadRepository)
        {
            _publisherReadRepository = publisherReadRepository;
        }
        public async Task PublisherNameIsExists(string name)
        {
            StringHelper.ToLowerAndRemoveSpaces(name);
            bool isExists = await _publisherReadRepository.IsExist(x => x.PublisherName.ToLower().Replace(" ", "") == name);
            if (!isExists) throw new BusinessException($"{name}: Already Exists");
        }
        public async Task PublisherIsNotExists(int id)
        {
            bool fromDb = await _publisherReadRepository.IsExist(x => x.Id == id);
            if (!fromDb) throw new BusinessException("Publisher IsNot Exists");
        }
    }
}
