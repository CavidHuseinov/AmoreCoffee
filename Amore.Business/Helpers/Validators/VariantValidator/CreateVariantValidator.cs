using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Variant;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.VariantValidator
{
    public class CreateVariantValidator : AbstractValidator<CreateVariantDto>
    {
        public CreateVariantValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

        }
    }
}
