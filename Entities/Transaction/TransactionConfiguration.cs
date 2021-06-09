using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Transaction
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable(nameof(Transaction), nameof(SchemaEnum.TRANSACTION));
            builder.Property(p => p.phoneId).IsRequired();
            builder.Property(p => p.smsId).IsRequired();
            builder.Property(p => p.transaction).IsRequired();
            builder.Property(p => p.type).IsRequired();
            builder.HasOne(o => o.phone).WithMany(w => w.Transactions).HasForeignKey(f => f.phoneId);
            builder.HasOne(o => o.sms).WithMany(w => w.Transactions).HasForeignKey(f => f.smsId);

            builder.HasIndex(i => i.type);
            builder.HasIndex(i => i.phoneId);
        }
    }
}