using FluentValidation;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidation :AbstractValidator<CreateAuthorCommandRequest>
    {
        public CreateAuthorCommandValidation()
        {
            RuleFor(p=>p.AuthorFirstName).NotEmpty().WithMessage("Yazarın adı boş girilemez.")
                .MinimumLength(4).WithMessage("Yazar Adı minimum 4 harfli olmalıdır.");
            RuleFor(p => p.AuthorLastName).NotEmpty().WithMessage("Yazarın soyadı boş girilemez")
                .MinimumLength(4).WithMessage("Yazarın soyadı minimum 4 harfli olmalıdır.");
        }
    }
}
