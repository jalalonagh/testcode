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
    
    public partial class PrdcWorkOrderDMaterial
    {
        public int PrdcWorkOrderDMaterial_Si { get; set; }
        public Nullable<int> PrdcWorkOrderDInfo_Si { get; set; }
        public Nullable<int> InvGds_Si { get; set; }
        public Nullable<double> PrdcWorkOrderDMaterial_Value { get; set; }
        public Nullable<int> PrdcBOMD_Si { get; set; }
    
        public virtual InvGd InvGd { get; set; }
        public virtual PrdcWorkOrderDInfo PrdcWorkOrderDInfo { get; set; }
    }
}
