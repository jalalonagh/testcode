using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplierSystem.Entities.Barecode
{
    internal class BarecodeConfiguration : IEntityTypeConfiguration<Barcode>
    {
        public void Configure(EntityTypeBuilder<Barcode> builder)
        {
            builder.ToTable(nameof(Barcode), nameof(SchemaEnum.SUPPLIER));
            builder.Property(i => i.Used).IsRequired();
            builder.Property(i => i.Code).IsRequired();
        }
    }
}
