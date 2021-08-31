using FluentValidation;

namespace ManaEntitiesValidation.Profile.FavoriteProduct
{
    internal class FavoriteProductValidator : AbstractValidator<Entities.Profile.FavoriteProduct.FavoriteProduct>
    {
        public FavoriteProductValidator()
        {
            RuleFor(x => x.ProductId).NotNull().GreaterThan(0).WithMessage("شناسه محصول ضروری است");
            RuleFor(x => x.ProfileId).NotNull().GreaterThan(0).WithMessage("شناسه پروفایل ضروری است");
        }
    }
}