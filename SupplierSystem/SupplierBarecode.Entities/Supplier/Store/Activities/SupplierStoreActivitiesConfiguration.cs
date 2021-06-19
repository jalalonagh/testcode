using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplierSystem.Entities.Supplier.Store.Activities
{
    internal class SupplierStoreActivitiesConfiguration : IEntityTypeConfiguration<SupplierStoreActivities>
    {
        public void Configure(EntityTypeBuilder<SupplierStoreActivities> builder)
        {
            builder.ToTable(nameof(SupplierStoreActivities), nameof(SchemaEnum.SUPPLIER));

            builder.Property(z => z.StoreId).IsRequired();
            builder.Property(z => z.TargetProfileId).IsRequired();
            builder.Property(z => z.Summary).IsRequired();

            builder.HasOne(z => z.Store).WithMany(z => z.Activities).HasForeignKey(z => z.StoreId);
        }
    }
}
