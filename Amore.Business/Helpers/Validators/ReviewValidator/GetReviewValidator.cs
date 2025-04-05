using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Review;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.ReviewValidator
{
    public class GetReviewValidator : AbstractValidator<GetReviewDto>
    {
        public GetReviewValidator()
        {
            RuleFor(x => x.Comment).MaximumLength(400).WithMessage("Maksimum simvol sayı 400-dür.");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Məhsulu dəyərləndirin.");
            RuleFor(x => x.Rating).ExclusiveBetween(1, 5).WithMessage("1 ilə 5 arası dəyərləndirin zəhmət olmasa.");
        }
    }
}
