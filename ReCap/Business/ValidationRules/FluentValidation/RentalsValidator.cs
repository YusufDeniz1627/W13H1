using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalsValidator : AbstractValidator<Rental>
    {
        public RentalsValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.RentDate).NotNull();
            RuleFor(r => r.ReturnDate).NotNull();
        }
    }
}
