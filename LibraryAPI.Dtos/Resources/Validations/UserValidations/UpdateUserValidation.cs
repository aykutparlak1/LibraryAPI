using FluentValidation;
using LibraryAPI.Dtos.Resources.UserResorces;
using System.Text.RegularExpressions;

namespace LibraryAPI.Dtos.Resources.Validations.UserValidations
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("User id boş bırakılamaz ve 0'dan büyük olmalıdır.");
            RuleFor(x => x.IdentityNumber).NotEmpty().GreaterThan(9999999999).LessThan(100000000000).WithMessage("TC kimlik numarası 11 haneli olmalıdır.");
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).WithMessage("İsim boş bırakılamaz ve en az 3 harfli olmalıdır.");
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).WithMessage("Soyad boş bırakılamaz ve en az 3 harfli olmalıdır.");
            RuleFor(x => x.Email).NotEmpty().Must(MustEmail).WithMessage("Email formatı doğru değil.");
            RuleFor(x => x.BirthDate).NotEmpty().NotNull().WithMessage("Doğum günü boş bırakılmamalı.");
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("kullanıcı adı boş bırakılmamalı");
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("Telefon numarası boş bırakılmamalı")
                .Must(MustPhoneNumber).WithMessage("telefon numarası 0xxxxxxxxxx şeklinde olamalıdır.");

        }
        private bool MustPhoneNumber(string phoneNumber)  
        {
            return Regex.IsMatch(phoneNumber, @"^(0(\d{10}))$");
        }
        private bool MustEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
