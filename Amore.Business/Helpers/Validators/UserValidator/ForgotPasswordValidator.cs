using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.User;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.UserValidator
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().EmailAddress().WithMessage("Emailinizi doğru qeyd edin.");
        }
    }
}
