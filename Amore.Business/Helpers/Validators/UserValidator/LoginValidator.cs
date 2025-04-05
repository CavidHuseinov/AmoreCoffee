using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.User;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.UserValidator
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
               .NotEmpty().WithMessage("İstifadəçi adınızı və ya Email adressinizi qeyd edin");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrəni daxil edin")
                .NotNull().WithMessage("Şifrəni daxil edin")
                .MinimumLength(8).WithMessage("Şifrəniz minimum 8 simvol olmalıdır.")
                .MaximumLength(30).WithMessage("Şifrəniz maksimum 30 simvol olmalıdır.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$")
                .WithMessage("Şifrə ən azı 8 simvol olmalı, bir böyük hərf, bir kiçik hərf və bir rəqəm olmalıdır.");
        }
    }
}
