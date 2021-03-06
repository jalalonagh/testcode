using FluentValidation;

namespace ManaEntitiesValidation.User.ChairToUser
{
    public class ChairToUserValidator : AbstractValidator<Entities.User.ChairToUser.ChairToUser>
    {
        public ChairToUserValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.ChairId).NotNull().GreaterThan(0).WithMessage("");
        }
    }
}
