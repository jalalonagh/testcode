//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rrrrrrrrrrrrrrrrrrr
{
    using System;
    using System.Collections.Generic;
    
    public partial class WarehouseChargingInvgd
    {
        public int id { get; set; }
        public string invgds_cu { get; set; }
        public Nullable<decimal> price { get; set; }
        public string purvndr_cu { get; set; }
        public Nullable<int> WarehouseCharging_doc_id { get; set; }
        public Nullable<int> some_byCreator { get; set; }
        public Nullable<int> some_byConfirm { get; set; }
        public string typePay { get; set; }
    
        public virtual DocWarehouseCharging DocWarehouseCharging { get; set; }
    }
}