using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidation : AbstractValidator<DeleteAuthorCommandRequest>
    {
        public DeleteAuthorCommandValidation() 
        {
            RuleFor(p=>p.Id).NotEmpty().WithMessage("Id Boş Olamaz");
        }
    }
}
