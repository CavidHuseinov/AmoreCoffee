using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Variant;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.VariantValidator
{
    public class GetVariantValidator : AbstractValidator<GetVariantDto>
    {
        public GetVariantValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
