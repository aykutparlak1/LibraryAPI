using FluentValidation;
using LibraryAPI.Dtos.Resources.BarrowBookResources;

namespace LibraryAPI.Dtos.Resources.Validations.BarrowBookValidations
{
    public class BarrowBookValidation : AbstractValidator<BarrowBookDto>
    {
        public BarrowBookValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş bırakılamaz").GreaterThan(0).WithMessage("Id sıfır ve sıfırdan kücük olamaz.");
            RuleFor(x => x.BookId).NotEmpty().WithMessage("BookId boş bırakılamaz").GreaterThan(0).WithMessage("BookId sıfır ve sıfırdan kücük olamaz.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId boş bırakılamaz").GreaterThan(0).WithMessage("UserId sıfır ve sıfırdan kücük olamaz.");
            RuleFor(x => x.BarrowStartDate).NotEmpty().WithMessage("Ödünç alma tarihi boş bırakılamaz.");
            RuleFor(x => x.BarrowEndDate).NotEmpty().WithMessage("Ödünç teslim  tarihi boş bırakılamaz.");
        }

    }
}
