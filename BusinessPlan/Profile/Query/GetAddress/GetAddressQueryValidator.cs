//using Common.Resource;
//using FluentValidation;
//using Services.Profile;
//using System.Resources;

//namespace BusinessLayout.Profile.Query.GetAddress
//{
//    public class GetAddressQueryValidator : AbstractValidator<GetAddressQuery>
//    {
//        public GetAddressQueryValidator(ResourceManager resourceManager, IProfileService profileService)
//        {
//            RuleFor(a => a.Username)
//                .NotEmpty()
//                .WithMessage(resourceManager.GetString(ResourceKey.EmptyUsername));

//            RuleFor(a => a.Username)
//                .MustAsync(async (u, cancellation) => (await profileService.ProfileExists(u)).IsSuccess)
//                .WithMessage(resourceManager.GetString(ResourceKey.NotFoundUser));
//        }
//    }
//}