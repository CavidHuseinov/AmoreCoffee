using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.User;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.UserValidator
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad hissəsi boş olmamalıdır")
                .MinimumLength(3).WithMessage("Adınız minimum 3 simvoldan ibarət olmalıdır")
                .MaximumLength(20).WithMessage("Adınız maksimum 20 simvoldan ibarət olmalıdır");
            RuleFor(x=>x.Surname)
                .NotEmpty().WithMessage("Soyad hissəsi boş olmamalıdır")
                .MinimumLength(3).WithMessage("Soyadınız minimum 3 simvoldan ibarət olmalıdır")
                .MaximumLength(20).WithMessage("Soyadınız maksimum 20 simvoldan ibarət olmalıdır");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Cinsinizi qeyd edin");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Doğum tarihinizi qeyd edin");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("İstifadəçi adınızı qeyd edin")
                .MinimumLength(5).WithMessage("Istifadəçi adınız minimum 5 simvol olmalıdır")
                .MaximumLength(30).WithMessage("Istfadəçi adınız maksimum 30 simvol olmalıdır");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Doğru email formatı daxil edin")
                .NotEmpty().WithMessage("Email adressinizi qeyd edin");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrəni təyin edin")
                .NotNull().WithMessage("Şifrəni təyin edin")
                .MinimumLength(8).WithMessage("Şifrəniz minimum 8 simvol olmalıdır.")
                .MaximumLength(30).WithMessage("Şifrəniz maksimum 30 simvol olmalıdır.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$")
                .WithMessage("Şifrə ən azı 8 simvol olmalı, bir böyük hərf, bir kiçik hərf və bir rəqəm olmalıdır.");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .NotEmpty().WithMessage("Şifrəni təsdiqlə hissəsini doldurun");
        }
    }
}
