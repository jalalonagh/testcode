using FluentValidation;
using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManaEntitiesValidation.Profile.PhoneNumberType
{
    internal class PhoneNumberTypeValidator : AbstractValidator<Entities.Profile.PhoneNumberType.PhoneNumberType>
    {
        public PhoneNumberTypeValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("توضیح لازم است");
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("شناسه لازم است");
        }
    }
}