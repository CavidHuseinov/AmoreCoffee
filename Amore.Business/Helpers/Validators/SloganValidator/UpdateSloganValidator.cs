using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Slogan;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.SloganValidator
{
    public class UpdateSloganValidator : AbstractValidator<UpdateSloganDto>
    {
        public UpdateSloganValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Zəhmət olmasa banner mətnini daxil edin.");
        }
    }
}
