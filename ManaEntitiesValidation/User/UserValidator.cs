using FluentValidation;

namespace ManaEntitiesValidation.User
{
    public class UserValidator : AbstractValidator<Entities.User.User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("");
            RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage("");
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("");
        }
    }
}