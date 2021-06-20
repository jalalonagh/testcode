using ManaBaseEntity.Common;

namespace Entities.Warehouse
{
    public class SupplierStoreSeach : BaseSearchEntity
    {
        public string AccountingSystemId { get; set; }
        public string StoreCode { get; set; }
        public string StoreType { get; set; }
        public string LocationLng { get; set; }
        public string OutDoorAddress { get; set; }
        public string InDoorAddress { get; set; }
        public string Status { get; set; }
    }
}
