//using Common.Resource;
//using Common.Utilities;
//using FluentValidation;
//using Services.Profile;
//using System.Resources;

//namespace BusinessLayout.Profile.Command.InsertNew
//{
//    public class InsertNewCommandValidator : AbstractValidator<InsertNewCommand>
//    {
//        public InsertNewCommandValidator(ResourceManager resourceManager, IProfileService profileService)
//        {
//            RuleFor(p => p.Username)
//                .NotEmpty()
//                .WithMessage(resourceManager.GetString(ResourceKey.EmptyUsername));

//            RuleFor(p => p.Password)
//                .NotNull()
//                .NotEmpty()
//                .MinimumLength(4)
//                .WithMessage(resourceManager.GetString(ResourceKey.InvalidImageFileFormat));

//            RuleFor(a => a.Username)
//                .MustAsync(async (u, cancellation) => (await profileService.ProfileExists(u)).IsSuccess)
//                .WithMessage(resourceManager.GetString(ResourceKey.NotFoundUser));
//        }
//    }
//}