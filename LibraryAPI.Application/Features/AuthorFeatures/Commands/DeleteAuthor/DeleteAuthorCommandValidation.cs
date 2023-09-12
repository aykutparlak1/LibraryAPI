using FluentValidation;

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
