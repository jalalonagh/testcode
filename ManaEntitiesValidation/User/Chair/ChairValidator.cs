using FluentValidation;

namespace ManaEntitiesValidation.User.Chair
{
    public class ChairValidator : AbstractValidator<Entities.User.Chair.Chair>
    {
        public ChairValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("");
        }
    }
}
