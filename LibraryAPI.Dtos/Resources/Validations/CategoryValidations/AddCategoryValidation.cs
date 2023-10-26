using FluentValidation;
using LibraryAPI.Dtos.Resources.CategoryResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Dtos.Resources.Validations.CategoryValidations
{
    public class AddCategoryValidation : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryValidation()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori Adı boş bırakılamaz").MinimumLength(3).WithMessage("Kategori adı en az 3 harfli olmalıdır.");
        }
    }
}
