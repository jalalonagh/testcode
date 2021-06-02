using System.ComponentModel.DataAnnotations;
using FluentValidation;
using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManaEntitiesValidation.Profile.PhoneNumber
{
    internal class PhoneNumberValidator : AbstractValidator<Entities.Profile.PhoneNumber.PhoneNumber>
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x.Number).NotNull().NotEmpty().WithMessage("شناسه محصول ضروری است");
        }
    }
}