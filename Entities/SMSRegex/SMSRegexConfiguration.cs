using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Entities.SMSRegex
{
    internal class SMSRegexConfiguration : IEntityTypeConfiguration<SMSRegex>
    {
        public void Configure(EntityTypeBuilder<SMSRegex> builder)
        {
            builder.ToTable(nameof(SMSRegex), nameof(SchemaEnum.SMS));
            builder.Property(p => p.regex).IsRequired();
            builder.Property(p => p.type).IsRequired();

            builder.HasIndex(i => i.type);
        }
    }
}