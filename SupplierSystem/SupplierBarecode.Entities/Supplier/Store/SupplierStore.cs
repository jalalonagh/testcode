using ManaBaseEntity.Common;
using SupplierSystem.Entities.Supplier.Barecode;
using SupplierSystem.Entities.Supplier.Store.Activities;
using System.Collections.Generic;

namespace SupplierSystem.Entities.Supplier.Store
{
    public class SupplierStore : BaseEntity
    {
        public int SupplierId { get; set; }
        public string AccountingSystemId { get; set; }
        public string StoreCode { get; set; }
        public string StoreType { get; set; }
        public double LocationLat { get; set; }
        public string LocationLng { get; set; }
        public string OutDoorAddress { get; set; }
        public string InDoorAddress { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int DimensionZ { get; set; }
        public double CapacityCBM { get; set; }
        public double MaximumCapacityCBM { get; set; }
        public string Status { get; set; }
        public bool IsActiveToSale { get; set; }

        public IEnumerable<SupplierStoreActivities> Activities { get; set; }
        public IEnumerable<SupplierBarecode> Barcodes { get; set; }
    }
}
