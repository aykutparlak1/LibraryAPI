using AutoMapper;
using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Aspects.Autofac.ValidationAspects;
using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Dtos.Resources.BarrowBookResources;
using LibraryAPI.Dtos.Resources.Validations.AuthorValidations;
using LibraryAPI.Dtos.Resources.Validations.BarrowBookValidations;

namespace LibraryAPI.Application.Services.WriteServices.BarrowBookServices
{
    public class BarrowBookWriteManager : IBarrowBookWriteService
    {
        private readonly IBarrowedBookWriteRepository _barrowedBookWriteRepository;
        private readonly BarrowBookBusinessRules _barrowBookBusinessRules;
        private readonly IMapper _mapper;


        public BarrowBookWriteManager(IBarrowedBookWriteRepository barrowedBookWriteRepository, BarrowBookBusinessRules barrowBookBusinessRules,IMapper mapper)
        {
            _barrowBookBusinessRules = barrowBookBusinessRules;
            _barrowedBookWriteRepository = barrowedBookWriteRepository;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(BarrowBookValidation))]
        public async Task<BarrowBookDto> AddBarrowedBook(BarrowBookDto barrowBookDto)
        {
            await _barrowBookBusinessRules.BookIsExists(barrowBookDto.BookId);
            await _barrowBookBusinessRules.UserIsExists(barrowBookDto.UserId);
            await _barrowBookBusinessRules.BookAlreadyBarrowed(barrowBookDto.Id);
            _barrowBookBusinessRules.BarrowEndTimeCantBeEqualsOrLessThanBarrowStartDate(barrowBookDto.BarrowStartDate,barrowBookDto.BarrowEndDate);
            BarrowedBook mappedBarrowBook = _mapper.Map<BarrowedBook>(barrowBookDto);
            var addedBb=_barrowedBookWriteRepository.Add(mappedBarrowBook);
            await _barrowedBookWriteRepository.SaveAsync();
            BarrowBookDto mappedAddedBb = _mapper.Map<BarrowBookDto>(addedBb);
            return mappedAddedBb;
        }


        public async Task<bool> DeleteBarrowedBook(int id)
        {
            var result = await _barrowBookBusinessRules.IfBarrowedBookExistReturnAuthorOrThrowException(id);
            await _barrowBookBusinessRules.NotAllowedUntilBookAtBarrow(id);
            bool isRemoved = _barrowedBookWriteRepository.Remove(result);
            await _barrowedBookWriteRepository.SaveAsync();
            return isRemoved;
        }
        [ValidationAspect(typeof(BarrowBookValidation))]
        public async Task<BarrowBookDto> UpdateABarrow(BarrowBookDto barrowedBook)
        { 
            await _barrowBookBusinessRules.BarrowIsExists(barrowedBook.Id);
            await _barrowBookBusinessRules.UserIsExists(barrowedBook.UserId);
            await _barrowBookBusinessRules.BookIsExists(barrowedBook.BookId);
            BarrowedBook mappedBook = _mapper.Map<BarrowedBook>(barrowedBook);
            var updatedBb= _barrowedBookWriteRepository.Update(mappedBook);
            await _barrowedBookWriteRepository.SaveAsync();
            BarrowBookDto mappedUpdatedBb = _mapper.Map<BarrowBookDto>(updatedBb);
            return mappedUpdatedBb;
        }
    }
}
