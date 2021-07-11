using FluentValidation;
using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ManaEntitiesValidation.SMSRegex
{
    internal class SMSRegexValidator : AbstractValidator<Entities.SMSRegex.SMSRegex>
    {
        public SMSRegexValidator()
        {
            RuleFor(x => x.regex).NotNull().NotEmpty().WithMessage("");
        }
    }
}