using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Entities.SMS
{
    internal class SMSConfiguration : IEntityTypeConfiguration<SMS>
    {
        public void Configure(EntityTypeBuilder<SMS> builder)
        {
            builder.ToTable(nameof(SMS), nameof(SchemaEnum.SMS));

            builder.Property(p => p.phone).IsRequired();
            builder.Property(p => p.smsText).IsRequired();

            builder.HasIndex(i => i.phone);
            builder.HasIndex(i => i.CreateTime);
        }
    }
}