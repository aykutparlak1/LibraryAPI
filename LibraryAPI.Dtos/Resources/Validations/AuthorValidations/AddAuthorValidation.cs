using FluentValidation;
using LibraryAPI.Dtos.Resources.AuthorResources;

namespace LibraryAPI.Dtos.Resources.Validations.AuthorValidations
{
    public class AddAuthorValidation :AbstractValidator<AddAuthorDto>
    {
        public AddAuthorValidation()
        {
                RuleFor(x=>x.AuthorName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz. ").MinimumLength(5).WithMessage("Yazar adı en az 5 harf olmalıdır.");
        }
    }
}
