using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidation : AbstractValidator<UpdateAuthorCommandRequest>
    {
        public UpdateAuthorCommandValidation()
        {
            RuleFor(p => p.AuthorFirstName).NotEmpty().WithMessage("Yazarın adı boş girilemez.")
                    .MinimumLength(4).WithMessage("Yazar Adı minimum 4 harfli olmalıdır.");
            RuleFor(p => p.AuthorLastName).NotEmpty().WithMessage("Yazarın soyadı boş girilemez")
                .MinimumLength(4).WithMessage("Yazarın soyadı minimum 4 harfli olmalıdır.");
        }
    }
}
