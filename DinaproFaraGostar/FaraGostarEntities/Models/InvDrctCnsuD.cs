//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rrrrrrrrrrrrrrrrrrr.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvDrctCnsuD
    {
        public int InvDrctCnsuH_Si { get; set; }
        public int InvGds_Si { get; set; }
        public double InvDrctCnsuD_Qty { get; set; }
        public Nullable<decimal> InvDrctCnsuD_UntPrc { get; set; }
        public Nullable<decimal> InvDrctCnsuD_Total { get; set; }
        public Nullable<int> PurRqstH_Si { get; set; }
        public Nullable<int> InvUnt_Si { get; set; }
    
        public virtual InvDrctCnsuH InvDrctCnsuH { get; set; }
        public virtual InvGd InvGd { get; set; }
    }
}