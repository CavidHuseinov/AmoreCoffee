using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.HeadBanner;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.HeadBannerValdiator
{
    public class UpdateHeadBannerValidator : AbstractValidator<UpdateHeadBannerDto>
    {
        public UpdateHeadBannerValidator()
        {

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Zəhmət olmasa banner mətnini daxil edin.");
        }
    }
}
