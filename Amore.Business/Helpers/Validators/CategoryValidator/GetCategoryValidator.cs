using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Category;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.CategoryValidator
{
    public class GetCategoryValidator : AbstractValidator<GetCategoryDto>
    {
        public GetCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Başlıq hissəsin doldurun zəhmət olmasa");
        }
    }
}
