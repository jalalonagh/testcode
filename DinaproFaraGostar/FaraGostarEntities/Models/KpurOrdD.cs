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
    
    public partial class KpurOrdD
    {
        public int purOrdD_Si { get; set; }
        public Nullable<int> InvGds_Si { get; set; }
        public Nullable<double> purOrdD_Qty { get; set; }
        public Nullable<int> purOrdH_Si { get; set; }
        public Nullable<double> purOrdD_Prc { get; set; }
        public Nullable<int> PurRqstD_Si { get; set; }
    
        public virtual KPurOrdrH KPurOrdrH { get; set; }
    }
}