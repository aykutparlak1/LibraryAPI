using FluentValidation;
using LibraryAPI.Dtos.Resources.BookResources;

namespace LibraryAPI.Dtos.Resources.Validations.BookValidations
{
    public class AddBookValidation : AbstractValidator<AddBookDto>
    {
        public AddBookValidation()
        {
            RuleFor(x => x.Authors).NotEmpty().NotNull().WithMessage("Yazarlar boş bırakılamaz.");
            RuleFor(x=>x.PublisherId).NotEmpty().GreaterThan(0).WithMessage("Yayın evi boş bırakılamaz.");
            RuleFor(x => x.NumberOfPages).NotEmpty().GreaterThan(0).WithMessage("Sayfa sayısı boş olamaz ve sıfırdan büyük olmalıdır.");
            RuleFor(x=>x.Location).NotEmpty().WithMessage("Lokasyon boş bırakılamaz").MinimumLength(2).WithMessage("Minimum 2 harfli olmalıdır.");
            RuleFor(x => x.BookName).NotEmpty().MinimumLength(3).WithMessage("Kitap ismi boş bırakılamaz ve en az 3 harfli olmalıdır.");
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0).WithMessage("Kategori boş bırakılamaz.");
    
        }
    }
}
