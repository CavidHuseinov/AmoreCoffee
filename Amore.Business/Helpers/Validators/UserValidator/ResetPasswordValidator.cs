using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.User;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.UserValidator
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Doğru email formatı daxil edin")
                .NotEmpty().WithMessage("Email adressinizi qeyd edin");
            RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Şifrəni sıfırlamaq üçün tokeni daxil edin.");
            RuleFor(x => x.NewPassword)
               .NotEmpty().WithMessage("Şifrəni təyin edin")
               .NotNull().WithMessage("Şifrəni təyin edin")
               .MinimumLength(8).WithMessage("Şifrəniz minimum 8 simvol olmalıdır.")
               .MaximumLength(30).WithMessage("Şifrəniz maksimum 30 simvol olmalıdır.")
               .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$")
               .WithMessage("Şifrə ən azı 8 simvol olmalı, bir böyük hərf, bir kiçik hərf və bir rəqəm olmalıdır.");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword)
                .NotEmpty().WithMessage("Şifrəni təsdiqlə hissəsini doldurun");
        }
    }
}
