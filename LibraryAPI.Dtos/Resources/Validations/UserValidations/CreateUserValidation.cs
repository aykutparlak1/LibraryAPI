using FluentValidation;
using LibraryAPI.Dtos.Resources.UserResorces;
using System.Text.RegularExpressions;

namespace LibraryAPI.Dtos.Resources.Validations.UserValidations
{
    public class CreateUserValidation : AbstractValidator<CreateUserDto>
    {
        private const int PasswordLength = 8;
        private const int MinDigitCount = 1;
        private const int MinUpperCaseCount = 1;
        private const int MinSpecialCharCount = 1;
        private const string SpecialCharacters = @"!@#$%^&*()-_=+[]{}|;:'<>,.?/";
        public CreateUserValidation()
        {
            RuleFor(x => x.IdentityNumber).NotEmpty().GreaterThan(9999999999).LessThan(100000000000).WithMessage("TC kimlik numarası 11 haneli olmalıdır.");
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).WithMessage("İsim boş bırakılamaz ve en az 3 harfli olmalıdır.");
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).WithMessage("Soyad boş bırakılamaz ve en az 3 harfli olmalıdır.");
            RuleFor(x => x.Email).NotEmpty().Must(MustEmail).WithMessage("Email formatı doğru değil.");
            RuleFor(x => x.BirthDate).NotEmpty().NotNull().WithMessage("Doğum günü boş bırakılmamalı.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(PasswordLength).WithMessage($"Şifre en az {PasswordLength} karakterli olamlı")
                .Must(MustMinDigit).WithMessage($"Minimum {MinDigitCount} rakam olmalı")
                .Must(MustUpperCase).WithMessage($"Minimum {MinUpperCaseCount} büyük harf olmalı");
                //.Must(MustSpecialChar).WithMessage($"Minimum {MinSpecialCharCount} özel karekter olmalı");
        }
        private bool MustMinDigit(string password)
        {
            return password.Count(char.IsDigit) >= MinDigitCount;
        }
        private bool MustUpperCase(string password)
        {
            return password.Count(char.IsUpper) >= MinUpperCaseCount;
        }
        private bool MustSpecialChar(string password)
        {
            return password.Count(c => SpecialCharacters.Contains(c)) >= MinSpecialCharCount;
        }
        private bool MustEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
