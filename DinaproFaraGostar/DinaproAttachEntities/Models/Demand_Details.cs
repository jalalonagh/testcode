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
    
    public partial class Demand_Details
    {
        public int id { get; set; }
        public Nullable<int> Demand_Id { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<decimal> Debit_Total { get; set; }
        public Nullable<decimal> DemandPrice { get; set; }
        public Nullable<decimal> Demand_Minimal { get; set; }
        public Nullable<bool> is_Financial_Ok { get; set; }
        public Nullable<decimal> Deposit { get; set; }
        public Nullable<System.DateTime> Deposit_Dm { get; set; }
        public Nullable<System.DateTime> Financial_Ok_Dm { get; set; }
        public string Salresp_Tp { get; set; }
        public Nullable<int> salcust_si { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string FileAttached { get; set; }
        public string FilePath { get; set; }
    
        public virtual Demand_Doc Demand_Doc { get; set; }
    }
}