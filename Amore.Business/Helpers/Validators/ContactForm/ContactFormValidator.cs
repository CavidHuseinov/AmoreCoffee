using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.ContactForm;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.ContactFormValidator
{
    public class ContactFormValidator : AbstractValidator<ContactFormDto>
    {
        public ContactFormValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad hissəsini doldurun zəhmət olmasa");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Düzgün email formatı doldurun zəhmət olmasa")
                .NotEmpty().WithMessage("Email hissəsini bo. buraxmayın zəhmət olmasa");
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Zəhmət olmasa rəy hissəsini boş buraxmayın.")
                .MaximumLength(500).WithMessage("Maksiumum yaza biləcəyiniz simvol sayı 500dür.");

        }
    }
}
