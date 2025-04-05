using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.ShippingInfo;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.ShippingInfoValidator
{
    public class GetShippingInfoValidator : AbstractValidator<GetShippingInfoDto>
    {
        public GetShippingInfoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad hissəsini qeyd edin zəhmət olmasa.");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad hissəsini qeyd edin zəhmət olmasa.");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email hissəsini doğru doldurun.")
                .NotEmpty().WithMessage("Email hissəsini doldurun.");
            RuleFor(x => x.StreetAdress)
                .NotEmpty().WithMessage("Adressinizi qeyd edin zəhmət olmasa.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şəhəri qeyd edin zəhmət olmasa.");
            RuleFor(x => x.Apartment)
                .NotEmpty().WithMessage("Mənzil / Blok / Digər qeyd edin zəhmət olmasa.");


        }
    }
}
