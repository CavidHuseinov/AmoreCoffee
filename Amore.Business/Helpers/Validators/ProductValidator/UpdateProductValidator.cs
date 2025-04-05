using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Product;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.ProductValidator
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Title)
              .NotEmpty().WithMessage("Məhsulunuza ad qoyun zəhmət olmasa");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Məhsulunuz haqqında kiçik bir məlumat qeyd edin");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Məhsulunuza qiymət təyin edin zəhmət olmasa")
                .GreaterThan(0).WithMessage("Məhsulunuz üçün olan qiynət mənfi ola bilməz");
            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100).WithMessage("Məhsulunuz üçün endirim intervalı 0-100 arasındadır");

        }
    }
}
