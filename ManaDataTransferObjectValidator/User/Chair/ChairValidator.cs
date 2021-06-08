using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaEntitiesValidation.User.Chair
{
    public class ChairValidator : AbstractValidator<Entities.User.Chair.Chair>
    {
        public ChairValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("");
        }
    }
}
