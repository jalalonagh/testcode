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
    
    public partial class InvRqstD
    {
        public int InvRqstD_Si { get; set; }
        public int InvRqstH_Si { get; set; }
        public double InvRqstD_Qty { get; set; }
        public string InvRqstD_Tp { get; set; }
        public Nullable<int> InvGds_Si { get; set; }
        public Nullable<int> AccLC_Si { get; set; }
        public Nullable<int> AccLP_Si { get; set; }
        public Nullable<int> PerPrsnl_Si { get; set; }
        public Nullable<byte> InvRqstSts_Si { get; set; }
        public Nullable<int> InvGdsTyp_Si { get; set; }
        public Nullable<double> InvRqstD_QtyAccept { get; set; }
        public Nullable<double> InvRqstD_QtyRemain { get; set; }
    
        public virtual InvRqstH InvRqstH { get; set; }
        public virtual InvRqstSt InvRqstSt { get; set; }
    }
}
