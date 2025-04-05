using Amore.Business.Helpers.DTOs.Promocode;
using FluentValidation;

namespace Amore.Business.Helpers.Validators.Promocode
{
    public class CreatePromocodeDtoValidator : AbstractValidator<CreatePromocodeDto>
    {
        public CreatePromocodeDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Promokodunuzu adlandırın")
                .Matches("^[A-Za-z0-9]+$").WithMessage("Promokod yalnız hərflər və rəqəmlərdən ibarət olmalıdr");

            RuleFor(x => x.DiscountPercentage)
                .GreaterThan(0).WithMessage("Endirim faizi 0'dan çox olmalıdır.")
                .LessThanOrEqualTo(100).WithMessage("Endirim faizi 100'dən kiçik olmalıdır");

            RuleFor(x => x.ExpirationDate)
                .GreaterThan(DateTime.Now).WithMessage("Bitmə müddəti gələcək müddət qeyd olunmalıdır");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Promo kodun aktivlik statusunu qeyd edin");
        }
    }
}
