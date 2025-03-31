using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Location;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.LocationValidator
{
    public class CreateLocationValidator:AbstractValidator<CreateLocationDto>
    {
        public CreateLocationValidator() {

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlıq hissəsini doldurun zəhmət olmasa");
            RuleFor(x => x.LocationName).NotEmpty().WithMessage("Ünvanınızın adını qeyd edin məsələn Səməd Vurğun 45 kimi....");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Nömrənizi daxil edin");
            RuleFor(x => x.EmailAdress).NotEmpty().WithMessage("Email adressinizi daxil edin").EmailAddress().WithMessage("Email adressinizi duzgun daxil edin");
        }
    }
}
