using FluentValidation;
using LibraryAPI.Dtos.Resources.PublisherResources;

namespace LibraryAPI.Dtos.Resources.Validations.PublisherValidations
{
    public class UpdatePublisherValidation: AbstractValidator<UpdatePublisherDto>
    {
        public UpdatePublisherValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage(" Yayın evi id'si boş bırakılamaz ve 0'dan büyük olmalıdır.");
            RuleFor(x => x.PublisherName).NotEmpty().MinimumLength(3).WithMessage("Yayın evi boş bırakılamaz ve en az 3 harfli olmalıdır.");
        }
    }
}
