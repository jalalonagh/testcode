using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Entities.SMSConfirmation
{
    internal class SMSConfirmationConfiguration : IEntityTypeConfiguration<SMSConfirmation>
    {
        public void Configure(EntityTypeBuilder<SMSConfirmation> builder)
        {
            builder.ToTable(nameof(SMSConfirmation), nameof(SchemaEnum.SMS));
            builder.Property(p => p.smsId).IsRequired();
            builder.Property(p => p.phoneId).IsRequired();
            builder.Property(p => p.confirmationText).IsRequired();

            builder.HasIndex(i => i.CreateTime);
        }
    }
}