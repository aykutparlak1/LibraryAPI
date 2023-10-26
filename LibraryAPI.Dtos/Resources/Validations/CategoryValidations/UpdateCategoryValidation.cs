using FluentValidation;
using LibraryAPI.Dtos.Resources.CategoryResources;

namespace LibraryAPI.Dtos.Resources.Validations.CategoryValidations
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("Kategori id boş bırakılamaz ve 0'dan üyük olmalıdır.");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı boş bırakılamaz").MinimumLength(3).WithMessage("Kategori adı en az 3 harfli olmalıdır.");
        }
    }
}
