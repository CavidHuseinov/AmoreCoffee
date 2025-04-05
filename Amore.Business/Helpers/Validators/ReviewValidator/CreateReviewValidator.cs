using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Review;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.ReviewValidator
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.Comment).MaximumLength(400).WithMessage("Maksimum simvol sayı 400-dür.");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Məhsulu dəyərləndirin.");
        }
    }
}
