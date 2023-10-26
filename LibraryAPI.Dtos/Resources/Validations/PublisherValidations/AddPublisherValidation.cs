using FluentValidation;
using LibraryAPI.Dtos.Resources.PublisherResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Dtos.Resources.Validations.PublisherValidations
{
    public class AddPublisherValidation : AbstractValidator<AddPublisherDto>
    {
        public AddPublisherValidation()
        {
            RuleFor(x=>x.PublisherName).NotEmpty().MinimumLength(3).WithMessage("Yayın evi boş bırakılamaz ve en az 3 harfli olmalıdır.");
        }
    }
}
