using ManaBaseEntity.Common;
using SupplierSystem.Entities.Supplier.Store;
using System;

namespace SupplierSystem.Entities.Supplier.Request
{
    public class SupplierSupplyRequest : BaseEntity
    {
        public string RequestCode { get; set; }
        public int StoreId { get; set; }
        public SupplierStore Store { get; set; }
        public string Status { get; set; }
        public TimeSpan TotalDoneTime { get; set; }
        public TimeSpan TotalPackingTime { get; set; }
        public TimeSpan TotalDelayTime { get; set; }
        public DateTime PackingStartTime { get; set; }
        public DateTime PackingFinishTime { get; set; }
        public DateTime RequestTime { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
