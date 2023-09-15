using FluentValidation;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.LoginUser
{
    public class LoginUserCommandValidation : AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserCommandValidation()
        {
            RuleFor(p=>p.Email).NotEmpty().WithMessage("Email boş bırakılamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş bırakılmaz");
        }
    }
}
