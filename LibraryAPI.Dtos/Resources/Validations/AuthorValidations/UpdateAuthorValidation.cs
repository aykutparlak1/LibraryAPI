using FluentValidation;
using LibraryAPI.Dtos.Resources.AuthorResources;

namespace LibraryAPI.Dtos.Resources.Validations.AuthorValidations
{
    public class UpdateAuthorValidation :AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş bırakılamaz").GreaterThan(0).WithMessage("Id sıfır ve sıfırdan kücük olamaz.");
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz. ").MinimumLength(5).WithMessage("Yazar adı en az 5 harf olmalıdır.");
        }
    }
}
