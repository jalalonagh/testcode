using FluentValidation;

namespace ManaEntitiesValidation.User.Role
{
    public class RoleValidator : AbstractValidator<Entities.User.Role.Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("");
        }
    }
}
