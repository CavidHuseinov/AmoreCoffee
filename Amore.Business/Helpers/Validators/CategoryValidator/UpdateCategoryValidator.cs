using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Category;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.CategoryValidator
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Başlıq hissəsin doldurun zəhmət olmasa");
        }
    }
}
