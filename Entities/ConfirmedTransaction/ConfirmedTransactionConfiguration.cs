using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Entities.ConfirmedTransaction
{
    internal class ConfirmedTransactionConfiguration : IEntityTypeConfiguration<ConfirmedTransaction>
    {
        public void Configure(EntityTypeBuilder<ConfirmedTransaction> builder)
        {
            builder.ToTable(nameof(ConfirmedTransaction), nameof(SchemaEnum.TRANSACTION));
            builder.Property(p => p.phoneId).IsRequired();
            builder.Property(p => p.transactionId).IsRequired();
        }
    }
}