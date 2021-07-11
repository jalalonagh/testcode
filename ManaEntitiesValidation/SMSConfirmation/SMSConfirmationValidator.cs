using FluentValidation;
using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ManaEntitiesValidation.SMSConfirmation
{
    internal class SMSConfirmationValidator : AbstractValidator<Entities.SMSConfirmation.SMSConfirmation>
    {
        public SMSConfirmationValidator()
        {
            RuleFor(x => x.phoneId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.smsId).NotNull().GreaterThan(0).WithMessage("");
            RuleFor(x => x.confirmationText).NotNull().NotEmpty().WithMessage("");
        }
    }
}