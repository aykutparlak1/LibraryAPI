using FluentValidation;

namespace LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser
{
    public class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserCommandValidation()
        {
            RuleFor(p=>p.FirstName).NotEmpty().WithMessage("Ad boş bırakılamaz");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad boş bırakılamaz");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email boş bırakılamaz");
            RuleFor(p => p.IdentityNumber).NotEmpty().WithMessage("Tc kimlik numarası Boş bırakılamaz");
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz").MaximumLength(5).WithMessage("Minimum 5 karakter uzunlugunda");
        }
    }
}
