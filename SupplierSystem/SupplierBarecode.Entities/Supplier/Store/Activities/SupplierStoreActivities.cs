using SupplierSystem.Entities.Common;

namespace SupplierSystem.Entities.Supplier.Store.Activities
{
    public class SupplierStoreActivities : BaseEntity
    {
        public int StoreId { get; set; }
        public SupplierStore Store { get; set; }
        public int TargetProfileId { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
    }
}
